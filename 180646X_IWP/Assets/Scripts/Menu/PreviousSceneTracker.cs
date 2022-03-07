using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreviousSceneTracker : Singleton<PreviousSceneTracker>
{
    [HideInInspector]
    public string PrevScene;

    private static string LastLevel;

    public static void SetLastLevel(string Level)
    {
        LastLevel = Level;
    }

    public static string GetLastLevel()
    {
        return LastLevel;
    }

    public static void ChangeToPrevLevel()
    {
        SceneManager.LoadScene(LastLevel);
    }

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
