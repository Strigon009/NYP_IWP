using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaIndicator : MonoBehaviour
{
    public Slider staminaBar;

    private int maxStamina = 100;
    private float currentStamina;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    public static StaminaIndicator instance;

    public DummyMovement player;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentStamina > 0)
        {
            if(Input.GetKey(KeyCode.LeftShift))
            {
                UseStamina(.009f);
            }
            player.walkSpeed = 3.5f;
            player.runSpeed = 5f;
        }
        if(currentStamina < 1)
        {
            staminaBar.value = currentStamina;
            player.runSpeed = player.walkSpeed;
        }
    }

    public void UseStamina(float amount)
    {
        if(currentStamina - amount >= 0)
        {
            currentStamina -= amount;
            staminaBar.value = currentStamina;

            if(regen != null)
            {
                StopCoroutine(regen);
            }

            regen = StartCoroutine(RegenStamina());
        }
    }

    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(1.5f);

        while(currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 100;
            staminaBar.value = currentStamina;
            yield return regenTick;
        }
    }
}
