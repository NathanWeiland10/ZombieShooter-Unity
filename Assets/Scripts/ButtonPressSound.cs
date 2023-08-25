using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressSound : MonoBehaviour
{

    public string soundEffect;


    public void playSoundEffect()
    {
        FindObjectOfType<AudioManager>().Play(soundEffect);
    }

}
