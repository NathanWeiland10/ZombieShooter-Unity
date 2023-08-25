using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseMenuOptions : MonoBehaviour
{

    public AudioMixer audioMixer;
    public Slider sliderPausedMenu;
    // public static float pausedMenuSliderValue;


    void Awake()
    {
        sliderPausedMenu.value = AudioSaver.currentVolume;
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", sliderPausedMenu.value);
    }

    void Update()
    {
        AudioSaver.currentVolume = sliderPausedMenu.value;
    }

    public void SetBloodAndGore(bool bloodEnabled)
    {
        AudioSaver.bloodEnabled = bloodEnabled;
    }

}