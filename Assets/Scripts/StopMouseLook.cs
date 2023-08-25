using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMouseLook : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("Hit Effect");
        }
    }
}