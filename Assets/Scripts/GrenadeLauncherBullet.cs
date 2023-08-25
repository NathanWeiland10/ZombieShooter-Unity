using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeLauncherBullet : MonoBehaviour
{
    public static float additionalDamage = 0;

    public GameObject hitBox;
    public ParticleSystem explosionEffect;
    public Rigidbody2D rb;
    public float damage = 40;
    public ParticleSystem effect;
    public string explosionSound;
    public ParticleSystem robotBloodEffect;
    public ParticleSystem zombieBloodEffect;
    public string robotDamageSound;
    public string enemyDamageSound;

    public float explodeAfter;

    void Update ()
    {
        explodeAfter -= Time.deltaTime;

        if (explodeAfter < 0)

        {
            Instantiate(zombieBloodEffect, transform.position, transform.rotation);
            Instantiate(explosionEffect, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play(explosionSound);
            StartCoroutine(HitBox());
            Destroy(gameObject);
        }

    }




    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play(explosionSound);
            enemy.TakeDamage(damage + (damage * additionalDamage));  
            FindObjectOfType<AudioManager>().Play(enemyDamageSound);
            PointsSystem.currentScore += 1;
            StartCoroutine(HitBox());
            Destroy(gameObject);

        }

        RobotBoss boss1 = hitInfo.GetComponent<RobotBoss>();
        if (boss1 != null)
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play(explosionSound);
            boss1.TakeDamage(damage + (damage * additionalDamage));
            FindObjectOfType<AudioManager>().Play(robotDamageSound);
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