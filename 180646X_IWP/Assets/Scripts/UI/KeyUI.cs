using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyUI : MonoBehaviour
{
    public KeyGate keyGate;

    public Text keyCollectText;

    // Update is called once per frame
    void Update()
    {
        keyCollectText.text = "Keys Collected: " + keyGate.keycount.ToString();
    }
}
