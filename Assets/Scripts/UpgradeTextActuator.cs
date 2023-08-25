using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeTextActuator : MonoBehaviour
{

    public GameObject upgradeDescription;



    void Start()
    {
        upgradeDescription.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerMovement player = hitInfo.GetComponent<PlayerMovement>();
        if (player != null)
        {
            upgradeDescription.SetActive(true);
            upgradeDescription.SetActive(true);
        }


    }

    private void OnTriggerExit2D(Collider2D hitInfo)
    {
        PlayerMovement player = hitInfo.GetComponent<PlayerMovement>();
        if (player != null)
        {
            upgradeDescription.SetActive(false);
            upgradeDescription.SetActive(false);
        }


    }
}