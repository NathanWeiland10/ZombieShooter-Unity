using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantiateUiOnCollision : MonoBehaviour
{
    public GameObject weapon;

    void Start ()
    {
      
    }

   void update ()

    {
        if(weapon == null)
           
        {
            FindObjectOfType<AudioManager>().Play("Hit Effect");
        }
    }


    }
