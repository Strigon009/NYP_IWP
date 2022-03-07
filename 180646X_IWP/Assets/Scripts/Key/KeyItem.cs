using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItem : MonoBehaviour
{
    public int KeyCount = 0;
    public BoxCollider Box;
    public GameObject KeyText;

    public KeyGate kGate;

    private bool PlayerInRange = false;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            PlayerInRange = true;
            KeyText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            PlayerInRange = false;
            KeyText.SetActive(false);
        }
    }

    private void Update()
    {
        if (PlayerInRange == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                kGate.keycount += 1;
                KeyText.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}
