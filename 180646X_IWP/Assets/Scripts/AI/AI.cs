using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    [SerializeField] Transform player;
    NavMeshAgent agent;

    public LayerMask LayerMaskGround, LayerMaskPlayer;
    public bool playerInSightRange;
    public float sightRange;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    
    public WanderType wanderType = WanderType.Random;
    public enum WanderType { Random, Waypoint};
    public Transform[] waypoints; // Array of waypoints is only used when waypoint is selected
    private int wayPointIndex = 0;

    //Attacking
    public Animator anim;
    public AIAttack aiAttack;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, LayerMaskPlayer);

        if (!playerInSightRange)
        {
            Patroling();
            Wander();
        }
        if (playerInSightRange)
        {
            ChasePlayer();
        }
    }

    private void Patroling()
    {
        if (!walkPointSet) 
            SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, LayerMaskGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);

        if (agent.remainingDistance < 3)
        {
            anim.SetBool("Attack", true);

            FaceTarget();

            aiAttack.AIAttacking();
            //playerHP.PlayerAttacked();
        }
        else
        {
            anim.SetBool("Attack", false);
        }
    }

    private void Wander()
    {
        // Waypoint wandering
        if(Vector3.Distance(waypoints[wayPointIndex].position, transform.position) < 2f)
        {
            if (wayPointIndex == waypoints.Length - 1)
            {
                wayPointIndex = 0;
            }
            else
            {
                wayPointIndex++;
            }
        }
        else
        {
            agent.SetDestination(waypoints[wayPointIndex].position);
        }
    }

    private void FaceTarget()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
