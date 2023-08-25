using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public bool countsDown = true;

    public Transform spawnPoint;
    public float exitForce = 20f;
    public string upgradeSpawnSound;

    private float valueChosen = 0;

    public float dropChance = 0;

    public double health = 100;
    public ParticleSystem bloodDoneToPlayer;
    public ParticleSystem zombieBloodEffect;
    public ParticleSystem deathEffect;
    public GameObject upgradeDrop;

    private bool isDying = false;

    public int damageToPlayer = 4;

    public float attackSpeed = 2f;
    float nextAttack = 0.0f;
    public string playerHurtSound;
    public string deathSound;

    [System.NonSerialized]
    float dropChanceWithLuck = 0;

    [System.NonSerialized]
    public static float luckIncrease = 0;

    public void TakeDamage(double damage)
    {
        health -= damage;

        if (health <= 0)
        {
            health = 0;

            if (isDying) return;
            isDying = true;

            dropChanceWithLuck =  100f * dropChance;
            valueChosen = UnityEngine.Random.Range(0, dropChanceWithLuck);
                Instantiate(deathEffect, transform.position, transform.rotation);

                if (valueChosen < (100f * (luckIncrease + 1)))
                {
                    GameObject drop = Instantiate(upgradeDrop, spawnPoint.position, spawnPoint.rotation);
                    Rigidbody2D rb = drop.GetComponent<Rigidbody2D>();
                    rb.AddForce(spawnPoint.up * exitForce, ForceMode2D.Impulse);
                    FindObjectOfType<AudioManager>().Play(upgradeSpawnSound);
                }


            else if (EnemySpawner.enemiesTillNextRound == 0 && EnemySpawner.enemiesOnScreen <= 1)
            {
                GameObject drop = Instantiate(upgradeDrop, spawnPoint.position, spawnPoint.rotation);
                Rigidbody2D rb = drop.GetComponent<Rigidbody2D>();
                rb.AddForce(spawnPoint.up * exitForce, ForceMode2D.Impulse);
                FindObjectOfType<AudioManager>().Play(upgradeSpawnSound);
            }


            StartCoroutine(Die());
            
        }

    }


        IEnumerator Die()
    {
        if (countsDown) {
            EnemySpawner.enemiesOnScreen--;
             }
        FindObjectOfType<AudioManager>().Play(deathSound);
        PointsSystem.currentScore += 9;
        Destroy(gameObject);
        yield return new WaitForSeconds(0.1f);
    }

   

    private void OnTriggerStay2D(Collider2D hitInfo)
    {
        PlayerMovement player = hitInfo.GetComponent<PlayerMovement>();
        if (player != null)


            if (Time.time > nextAttack)
            {
                nextAttack = Time.time + attackSpeed;
                player.PlayerTakeDamage(damageToPlayer);
                FindObjectOfType<AudioManager>().Play(playerHurtSound);

                if (AudioSaver.bloodEnabled) {
                    Instantiate(bloodDoneToPlayer, transform.position, transform.rotation);
                }
            }

    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Bullet bullet = hitInfo.GetComponent<Bullet>();
        if (bullet != null)



            if (AudioSaver.bloodEnabled)
            {
                Instantiate(zombieBloodEffect, transform.position, transform.rotation);
            }


    }


    void Update ()
    {
        isDying = false;
    }

}
