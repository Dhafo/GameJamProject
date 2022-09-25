using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class VolumeNumberScriptSFX : MonoBehaviour
{
    public TextMeshProUGUI numberText;
    public Slider slider;
    public AudioMixer mixer;

    public bool isMenu = false;
    public void SetNumberText(float value)
    {
        numberText.text = ((int)(value * 100)).ToString();
        mixer.SetFloat("SFXVol", Mathf.Log10(value) * 20);
    }
    public void moveSlider(float value) 
    {
        slider.value = value;
    }

    private void OnEnable()
    {
        if(!isMenu) 
        {
            float value = PlayerPrefs.GetFloat("SFXVol");
            SetNumberText(value);
            moveSlider(value);
        }
        else if (PlayerPrefs.HasKey("SFXVol"))
        {
            float value = PlayerPrefs.GetFloat("SFXVol");
            SetNumberText(value);
            moveSlider(value);
        }
        else
        {
            SetNumberText(1);
            moveSlider(1);
        }
    }
    private void OnDisable()
    {
        PlayerPrefs.SetFloat("SFXVol", slider.value);
    }
}
