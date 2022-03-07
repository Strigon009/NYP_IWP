using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Footsteps : MonoBehaviour
{
    public AudioClip[] ground;
    public AudioSource audioSource;
    public CharacterController cController;

    private bool stepWalk = true;
    private bool stepRun = true;

    public float audioStepLengthWalk;
    public float audioStepLengthRun;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        cController = GetComponent<CharacterController>();

        if(cController.isGrounded && cController.velocity.magnitude < 3.5 && cController.velocity.magnitude > 0 && hit.gameObject.tag == "Ground" && stepWalk == true)
        {
            StartCoroutine(WalkOnGround());
        }
        if (cController.isGrounded && cController.velocity.magnitude < 5 && cController.velocity.magnitude > 3.5 && hit.gameObject.tag == "Ground" && stepRun == true)
        {
            StartCoroutine(RunOnGround());
        }
    }

    private IEnumerator WalkOnGround()
    {
        stepWalk = false;
        audioSource.clip = ground[Random.Range(0, ground.Length)];
        audioSource.volume = 0.2f;
        audioSource.Play();
        yield return new WaitForSeconds(audioStepLengthWalk);
        stepWalk = true;
    }

    private IEnumerator RunOnGround()
    {
        stepRun = false;
        audioSource.clip = ground[Random.Range(0, ground.Length)];
        audioSource.volume = 0.2f;
        audioSource.Play();
        yield return new WaitForSeconds(audioStepLengthRun);
        stepRun = true;
    }
}
