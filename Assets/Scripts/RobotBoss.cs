using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotBoss : MonoBehaviour
{
    private bool inPhase2 = false;
    private bool phaseSound = true;

    private int RobotAttackRNG;


    public GameObject headIcon;
    public GameObject headIconPhase2;

    public double health = 100;
    public ParticleSystem blood;
    public ParticleSystem robotBloodEffect;
    public ParticleSystem deathEffect;
    public int damageToPlayer = 4;

    public float attackSpeed = 2f;
    float nextAttack = 0.0f;
    public string playerHurtSound;
    public string robotShotSound;
    
    public float coolDownTimer;
    public float attackRate = 10f;
    

    public GameObject robotBullet;
    public float bulletForce;
    public int bulletRecoil;

    public GameObject robotRocket;

    private bool isShooting;
    public float fireRate = 15f;

    public GameObject robotLaser;
    public bool isShootingLaser;
    public float laserFireRate = 30f;
    public float laserForce;

    public Transform gunAttack;
    public Transform rocketAttack;
    public Transform leftLaserAttack;
    public Transform rightLaserAttack;

    private Vector3 angle;

    private float nextTimeToFire = 0f;

   
    public string rocketLaunchedSound;
   

    public GameObject robotIcon1;
    public GameObject robotIcon2;

    void Start ()
    {
        headIcon.active = true;
        headIconPhase2.active = false;
        robotIcon1.active = true;
        robotIcon2.active = false;
        FindObjectOfType<AudioManager>().Play("Robot Fight");
        coolDownTimer = attackRate;
       
    }

    void Awake ()
    {
       
    }

    public void TakeDamage(double damage)
    {
        health -= damage;

        if (health <= 0)
        {
            
            Instantiate(deathEffect, transform.position, transform.rotation);
            StartCoroutine(Die());
            
        }

    }

    void Update ()
    {
        headIcon.transform.eulerAngles = new Vector3(0, 0, 0);
        headIconPhase2.transform.eulerAngles = new Vector3(0, 0, 0);



        RobotAttackRNG = UnityEngine.Random.Range(1, 4);

        angle.z = UnityEngine.Random.Range(-bulletRecoil, bulletRecoil);
        gunAttack.transform.localEulerAngles = new Vector3(0f, 0f, angle.z);

        if (health <= 250)
        {
            headIcon.active = false;
            headIconPhase2.active = true;
            inPhase2 = true;
            attackRate = 3.5f;
            robotIcon1.active = false;
            robotIcon2.active = true;

            if (phaseSound)
            {
                FindObjectOfType<AudioManager>().Play("Robot Phase True");
                phaseSound = false;
            }

            
        }

        if (coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
        }

        if (coolDownTimer <= 0)
        {
            coolDownTimer = 0;

        }

        if (coolDownTimer == 0 && RobotAttackRNG == 1)
        {
            StartCoroutine(Attack1());
        }

        if (coolDownTimer == 0 && RobotAttackRNG == 2)
        {
            StartCoroutine(Attack2());
        }

        if (coolDownTimer == 0 && RobotAttackRNG == 3)
        {
            StartCoroutine(Attack3());
        }

        if (isShooting && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();
        }

        if (isShootingLaser && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / laserFireRate;
            ShootLaser();
        }

    }

   

    IEnumerator Die()
    {
        FindObjectOfType<AudioManager>().Stop("Robot Fight");
        FindObjectOfType<AudioManager>().Play("Death Effect");
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
                Instantiate(blood, transform.position, transform.rotation);

            }

    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Bullet bullet = hitInfo.GetComponent<Bullet>();
        if (bullet != null)
        { 
            Instantiate(robotBloodEffect, transform.position, transform.rotation);
        }
}


IEnumerator Attack1()
    {
        coolDownTimer = attackRate;
        isShooting = true;
        yield return new WaitForSeconds(3f);
        isShooting = false;


    }

    IEnumerator Attack2()
    {
        coolDownTimer = attackRate;
        Instantiate(robotRocket, rocketAttack.position, rocketAttack.rotation);
        FindObjectOfType<AudioManager>().Play(rocketLaunchedSound);
        yield return new WaitForSeconds(0.5f);
        Instantiate(robotRocket, rocketAttack.position, rocketAttack.rotation);
        FindObjectOfType<AudioManager>().Play(rocketLaunchedSound);
        yield return new WaitForSeconds(0.5f);
        Instantiate(robotRocket, rocketAttack.position, rocketAttack.rotation);
        FindObjectOfType<AudioManager>().Play(rocketLaunchedSound);
        yield return new WaitForSeconds(0.5f);
    }

    IEnumerator Attack3()
    {
        if (inPhase2)
        {
            FindObjectOfType<AudioManager>().Play("Robot Laser Phase2");
        } else
        {
            FindObjectOfType<AudioManager>().Play("Robot Laser");
        }

        coolDownTimer = attackRate;
        isShootingLaser = true;
        yield return new WaitForSeconds(3f);
        isShootingLaser = false;

    }

    void Shoot()
    {
        GameObject bullet = Instantiate(robotBullet, gunAttack.position, gunAttack.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (inPhase2)
        {
            rb.AddForce(gunAttack.up * bulletForce * 2, ForceMode2D.Impulse);
            FindObjectOfType<AudioManager>().Play("Robot Shot Sound Phase2");
        } else
        {
            rb.AddForce(gunAttack.up * bulletForce, ForceMode2D.Impulse);
            FindObjectOfType<AudioManager>().Play(robotShotSound);
        }
    }

    void ShootLaser()
    {
        GameObject laser = Instantiate(robotLaser, leftLaserAttack.position, leftLaserAttack.rotation);
        GameObject laser2 = Instantiate(robotLaser, rightLaserAttack.position, rightLaserAttack.rotation);
        Rigidbody2D rb1 = laser.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = laser2.GetComponent<Rigidbody2D>();
        rb1.AddForce(leftLaserAttack.up * laserForce, ForceMode2D.Impulse);
        rb2.AddForce(rightLaserAttack.up * laserForce, ForceMode2D.Impulse);

        if (inPhase2)
        {
            laser.GetComponent<EnemyBullet>().cannotShootThroughWalls = false;
            laser.GetComponent<DestroyAfter>().fTimer = 3;
            laser2.GetComponent<EnemyBullet>().cannotShootThroughWalls = false;
            laser2.GetComponent<DestroyAfter>().fTimer = 3;
        }
    }

   
}