using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public bool GameIsPaused = false;

    public GameObject pauseMenu;

    // UI
    public GameObject playerUI;
    public Text gateText;
    public Text keyText;
    public Text batteryText;

    public DummyMovement Player;

    public AudioSource AIGrowl;
    public AudioSource audioPlayerHit;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
                
            }
            else
            {
                Pause();
                
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Player.enabled = true;
        playerUI.SetActive(true);
        gateText.enabled = true;
        keyText.enabled = true;
        batteryText.enabled = true;
        AIGrowl.UnPause();
        audioPlayerHit.UnPause();
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Player.enabled = false;
        playerUI.SetActive(false);
        gateText.enabled = false;
        keyText.enabled = false;
        batteryText.enabled = false;
        AIGrowl.Pause();
        audioPlayerHit.Pause();
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
