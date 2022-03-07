using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashScreen : MonoBehaviour
{
    public Camera startCamera;
    public GameObject splashScreen;
    public GameObject Player;
    public GameObject AI;
    public GameObject playerUI;
    public GameObject bloodScreen;

    // Start is called before the first frame update
    void Start()
    {
        OnStart();
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            OnClick();
        }
    }

    void OnStart()
    {
        startCamera.gameObject.SetActive(true);
        splashScreen.SetActive(true);
        Player.SetActive(false);
        AI.SetActive(false);
        playerUI.SetActive(false);
        bloodScreen.SetActive(false);
        Time.timeScale = 0f;
    }

    void OnClick()
    {
        startCamera.gameObject.SetActive(false);
        splashScreen.SetActive(false);
        Player.SetActive(true);
        AI.SetActive(true);
        playerUI.SetActive(true);
        bloodScreen.SetActive(true);
        Time.timeScale = 1f;
    }
}
