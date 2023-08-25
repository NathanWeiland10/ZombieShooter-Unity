using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public GameObject wallHitEffect;

    public static float additionalDamage = 0;

    public Rigidbody2D rb;
    public float damage = 40;
    public string hitWallSound;
    public string enemyHurtSound;
    public string robotHurtSound;
    public bool cannotPenetrate = true;
    public bool cannotPenetrateWalls = true;

    public bool isColliding = false;

    void OnTriggerEnter2D (Collider2D hitInfo)
    {
        

        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage + (damage * additionalDamage));
            PointsSystem.currentScore += 1;
            FindObjectOfType<AudioManager>().Play(enemyHurtSound);

            if (cannotPenetrate)
            {
                Destroy(gameObject);
            }

        }

        RobotBoss boss1 = hitInfo.GetComponent<RobotBoss>();
        if (boss1 != null)
        {
            boss1.TakeDamage(damage + (damage * additionalDamage));
            PointsSystem.currentScore += 1;
            FindObjectOfType<AudioManager>().Play(robotHurtSound);
            Destroy(gameObject);

            if (cannotPenetrate)
            {
                Destroy(gameObject);
            }
        }


        SolidTiles solid = hitInfo.GetComponent<SolidTiles>();
        if (solid != null)
        {
           

            if (cannotPenetrateWalls)
            {
                FindObjectOfType<AudioManager>().Play(hitWallSound);
                GameObject bullet = Instantiate(wallHitEffect, transform.position, transform.rotation);
                Destroy(gameObject);

            }
        }


    }

   


}