using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioBackground;
    public AudioMixer audioSensitivity;

    public void SetVolume(float volume)
    {
        audioBackground.SetFloat("volume", volume);
    }

    public void SetSensitivity(float sensitivity)
    {
        audioSensitivity.SetFloat("sensitivity", sensitivity);
    }
}
