using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryItem : MonoBehaviour
{
    public GameObject BatteryText;

    public float batteryPower;

    private bool PlayerInRange = false;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            PlayerInRange = true;
            BatteryText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            PlayerInRange = false;
            BatteryText.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerInRange == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                BatteryText.SetActive(false);
                GameObject.FindGameObjectWithTag("Player").GetComponent<Flashlight>().AddBatteryLife(batteryPower);
                Destroy(gameObject);
            }
        }
    }
}
