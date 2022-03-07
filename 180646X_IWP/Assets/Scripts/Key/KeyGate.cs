using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyGate : MonoBehaviour
{
    public GameObject Door;
    public KeyItem[] Key;
    public GameObject GateText;
    public GameObject Gate;

    private int numTargetKeys = 0;
    public int keycount = 0;

    private void Start()
    {
        numTargetKeys = Key.Length;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            GateText.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            GateText.SetActive(false);
        }
    }

    private bool IsOpenGateTextActive
    { 
        get
        {
            return GateText.activeInHierarchy;
        }
    }

    private void Update()
    {
        if(IsOpenGateTextActive)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (keycount == numTargetKeys)
                {
                    GateText.SetActive(false);
                    //DenyGateText.SetActive(false);
                    Destroy(Gate);
                    Destroy(Door);
                }
                else
                {
                    GateText.SetActive(true);
                    //DenyGateText.SetActive(true);
                    //StartCoroutine(ShowMessage());
                }
            }
        }
    }
}
