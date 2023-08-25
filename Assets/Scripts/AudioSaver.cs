using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioSaver : MonoBehaviour
{

    public static float currentVolume = 0;
    public static bool bloodEnabled = true;

    void Update()
    {
        DontDestroyOnLoad(gameObject);
    }



}
