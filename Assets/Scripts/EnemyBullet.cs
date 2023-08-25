using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{

    public int damageToPlayer = 4;
    public string playerHurtSound;
    public string hitWallSound;
    public ParticleSystem bloodEffect;
    public bool cannotShootThroughWalls;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerMovement player = hitInfo.GetComponent<PlayerMovement>();
        if (player != null)
        {
            player.PlayerTakeDamage(damageToPlayer);
            Instantiate(bloodEffect, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play(playerHurtSound);
            Destroy(gameObject);
        }

        SolidTiles solid = hitInfo.GetComponent<SolidTiles>();
        if (solid != null && cannotShootThroughWalls)
        {
            FindObjectOfType<AudioManager>().Play(hitWallSound);
            Destroy(gameObject);
        }


    }
        void Update()
    {
        
    }
}
