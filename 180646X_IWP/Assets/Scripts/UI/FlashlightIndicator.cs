using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashlightIndicator : MonoBehaviour
{
    public Slider slider;

    public void SetMaxLight(float lightNum)
    {
        slider.maxValue = lightNum;
        slider.value = lightNum;
    }    

    public void SetLight(float lightNum)
    {
        slider.value = lightNum;
    }
}
