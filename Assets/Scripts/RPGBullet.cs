using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class RPGBullet : MonoBehaviour
{
    public static float additionalDamage = 0;

    public GameObject hitBox;
    public ParticleSystem explosionEffect;
    public Rigidbody2D rb;
    public int damage = 40;
    public ParticleSystem effect;
    public string explosionSound;
    public ParticleSystem robotBloodEffect;
    public ParticleSystem zombieBloodEffect;
    public string robotDamageSound;

   


  


    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage + (damage * additionalDamage));
            Instantiate(zombieBloodEffect, transform.position, transform.rotation);
            Instantiate(explosionEffect, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play(explosionSound);
            PointsSystem.currentScore += 1;
            StartCoroutine(HitBox());
            Destroy(gameObject);

        }

        RobotBoss boss1 = hitInfo.GetComponent<RobotBoss>();
        if (boss1 != null)
        {
            boss1.TakeDamage(damage + (damage * additionalDamage));
            Instantiate(robotBloodEffect, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play(robotDamageSound);

            Instantiate(explosionEffect, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play(explosionSound);
            PointsSystem.currentScore += 1;
            StartCoroutine(HitBox());
            Destroy(gameObject);


        }

        SolidTiles solid = hitInfo.GetComponent<SolidTiles>();
        if (solid != null)
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play(explosionSound);
            StartCoroutine(HitBox());
            Destroy(gameObject);
        }

    }

    IEnumerator HitBox()
    {
        Instantiate(hitBox, transform.position, transform.rotation);
        yield return new WaitForSeconds(0.1f);
        Destroy(hitBox);
        Destroy(gameObject);
    }

    }