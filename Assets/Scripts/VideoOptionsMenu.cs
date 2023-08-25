using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VideoOptionsMenu : MonoBehaviour
{

    public Toggle bloodToggle;

    void Awake()
    {

        bloodToggle.isOn = AudioSaver.bloodEnabled;

    }

    public void SetBloodAndGore(bool bloodEnabled)
    {
        AudioSaver.bloodEnabled = bloodEnabled;
    }

    void Update()
    {
        AudioSaver.bloodEnabled = bloodToggle.isOn;
    }


}