using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public void ToMainMenu()
    {
        PreviousSceneTracker.Instance.PrevScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("MainMenu");
    }

    public void ToInGame()
    {
        PreviousSceneTracker.Instance.PrevScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Game");

        Time.timeScale = 1f;
    }

    public void ToOptions()
    {
        PreviousSceneTracker.Instance.PrevScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("Options");
    }

    public void ToExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
