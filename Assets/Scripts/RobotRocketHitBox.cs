using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotRocketHitBox : MonoBehaviour

{
    public int damageToPlayer = 10;


    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerMovement player = hitInfo.GetComponent<PlayerMovement>();
        if (player != null)
        {
            player.PlayerTakeDamage(damageToPlayer);
            Destroy(gameObject);
            Delete();
        }

        SolidTiles box = hitInfo.GetComponent<SolidTiles>();
        if (box != null)
        {
            Destroy(gameObject);
            Delete();
        }

    }

    void Delete()
    {
        Destroy(gameObject);
    }
}
