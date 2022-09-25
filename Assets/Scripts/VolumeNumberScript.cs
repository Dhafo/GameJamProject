using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class VolumeNumberScript : MonoBehaviour
{
    public TextMeshProUGUI numberText;
    public Slider slider;
    public AudioMixer mixer;

    public bool isMenu = false;
    public void SetNumberText(float value)
    {
        numberText.text = ((int)(value * 100)).ToString();
        mixer.SetFloat("MusicVol", Mathf.Log10(value) * 20);
    }

    public void moveSlider(float value)
    {
        slider.value = value;
    }

    private void OnEnable()
    {
        if (!isMenu)
        {
            float value = PlayerPrefs.GetFloat("MusicVol");
            SetNumberText(value);
            moveSlider(value);
        }
        else if (PlayerPrefs.HasKey("MusicVol"))
        {
            float value = PlayerPrefs.GetFloat("MusicVol");
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
        PlayerPrefs.SetFloat("MusicVol", slider.value);
    }
}
