using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundRPG : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerMovement player = hitInfo.GetComponent<PlayerMovement>();
        if (player != null)
        {
            Destroy(gameObject);
        }


    }
}