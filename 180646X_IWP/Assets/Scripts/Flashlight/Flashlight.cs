using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour
{
    public bool isEnabled = false;
    public GameObject lightSource;
    public bool failSafe = false;

    public float batteryLifeSecs;
    public float maxIntensity = 1.9f;
    private float batteryLife;
    public Light myLight;

    public AudioSource audioSource;

    public Image flashlightIcon;
    
    public FlashlightIndicator flashlightBar;

    private void Start()
    {
        lightSource.SetActive(false);

        myLight.GetComponent<Light>();
        batteryLife = myLight.intensity;

        flashlightIcon.enabled = false;

        flashlightBar.SetMaxLight(maxIntensity);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if (isEnabled == false && failSafe == false)
            {
                failSafe = true;
                lightSource.SetActive(true);
                isEnabled = true;
                flashlightIcon.enabled = true;
                audioSource.Play();
                StartCoroutine(FailSafe());
            }
            else if (isEnabled == true && failSafe == false)
            {
                failSafe = true;
                lightSource.SetActive(false);
                isEnabled = false;
                flashlightIcon.enabled = false;
                audioSource.Play();
                StartCoroutine(FailSafe());
            }
        }

        if(isEnabled == true)
        {
            myLight.enabled = true;
            myLight.intensity -= batteryLife / batteryLifeSecs * Time.deltaTime;

            flashlightBar.SetLight(myLight.intensity);
        }
        else
        {
            myLight.enabled = false;
        }
    }

    IEnumerator FailSafe()
    {
        yield return new WaitForSeconds(0.25f);
        failSafe = false;
    }

    public void AddBatteryLife(float batteryPower)
    {
        myLight.intensity += batteryPower;

        if(myLight.intensity > maxIntensity)
        {
            myLight.intensity = maxIntensity;
        }
    }
}
