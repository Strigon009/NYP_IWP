using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject PopUpText;
    public GameObject EscapeGround;

    public PlayerMovement playerMove;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            PopUpText.SetActive(true);
            playerMove.StopWalking();
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
