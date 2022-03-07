using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AIAttack : MonoBehaviour
{
    public PlayerHealth playerHp;

    public float attackDamage;

    // AI attack
    public bool alreadyAttacked = false;
    float coolDown = 0f;

    // Blood Screen UI
    public GameObject bloodScreenGO;
    public Image bloodScreen;
    float coolDownUI = 0f;

    public AudioSource playerHit;

    private void Start()
    {
        playerHit.Stop();

        bloodScreenGO.SetActive(false);
    }

    public void AIAttacking()
    {
        if (playerHp.playerHealth > 0)
        {
            // Attack Cooldown
            if (coolDown > 0)
                coolDown -= Time.deltaTime;
            else
            {
                alreadyAttacked = false;
                coolDown = 2f;

                playerHp.playerHealth -= attackDamage;

                playerHit.Play();

                bloodScreenGO.SetActive(true);

                FadeIn();

                // BloodScreen Cooldown
                if (coolDownUI > 0)
                    coolDownUI -= Time.deltaTime;
                else
                {
                    coolDown = 2f;
                    FadeOut();
                }
            }
        }
        else
        {
            alreadyAttacked = true;
        }
    }

    private void FadeIn()
    {
        bloodScreen.CrossFadeAlpha(1, 0f, false);
    }

    private void FadeOut()
    {
        bloodScreen.CrossFadeAlpha(0, 1, false);
    }
}
