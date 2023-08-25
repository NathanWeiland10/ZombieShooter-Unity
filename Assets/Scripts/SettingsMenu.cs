using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;
    public Slider sliderMainMenu;

    void Awake()
    {

        sliderMainMenu.value = AudioSaver.currentVolume;

    }

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("Volume", AudioSaver.currentVolume);
    }

   void Update ()
    {
        AudioSaver.currentVolume = sliderMainMenu.value;
    }


}
