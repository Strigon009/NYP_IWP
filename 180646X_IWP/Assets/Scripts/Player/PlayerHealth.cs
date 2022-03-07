using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth;

    public GameObject loseScreen;
    public GameObject playerUI;
    public GameObject pauseUI;
    public GameObject bloodScreenGO;

    public DummyMovement playerMove;

    public AudioSource AIGrowl;
    public AudioSource PlayerHit;

    private void Update()
    {
        if (playerHealth == 0)
        {
            loseScreen.SetActive(true);
            playerUI.SetActive(false);
            pauseUI.SetActive(false);
            bloodScreenGO.SetActive(false);
            playerMove.StopWalking();
            AIGrowl.Stop();
            PlayerHit.Stop();
            StartCoroutine(QuitApplication());
        }
    }

    public IEnumerator QuitApplication()
    {
        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene("MainMenu");

        Cursor.lockState = CursorLockMode.None;
    }
}
