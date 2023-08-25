using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundShotgun: MonoBehaviour
{
    public WeaponSwitching weaponSwitching;

    public GameObject Shotgun;

    int i = 0;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerMovement player = hitInfo.GetComponent<PlayerMovement>();
        if (player != null)
        {
            i++;
            Destroy(gameObject);
        }

        if (i == 1)
        {
            weaponSwitching.addWeaponToList(Shotgun);
        }

    }
}