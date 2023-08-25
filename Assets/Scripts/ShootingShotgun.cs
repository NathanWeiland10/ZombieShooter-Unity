using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class ShootingShotgun : MonoBehaviour
{

    public Transform firePoint1;
    public Transform firePoint2;
    public Transform firePoint3;
    public Transform firePoint4;
    public Transform firePoint5;




    public GameObject bulletPrefab;
    public float bulletForce = 20f;

    public float fireRate = 15f;
    private float nextTimeToFire = 0f;

    Vector2 movement;
    public int maxAmmo = 8;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;
    public string shootSound;

    public Text ammoDisplay;
    public Text clipSize;

    private Vector3 angle1;
    private Vector3 angle2;
    private Vector3 angle3;
    private Vector3 angle4;
    private Vector3 angle5;

    public int recoil;
    public int minForce;
    public int maxForce;

    private float bulletForce1;
    private float bulletForce2;
    private float bulletForce3;
    private float bulletForce4;
    private float bulletForce5;

    public float bulletScreenShake = 4f;
    public float currentScreenShake;


    void Start()
    {
        currentAmmo = maxAmmo;
    }

    void OnEnable()
    {
        isReloading = false;
    }

    void Update()
    {
        currentScreenShake = bulletScreenShake;

        angle1.z = UnityEngine.Random.Range(-recoil, recoil);
        angle2.z = UnityEngine.Random.Range(-recoil, recoil);
        angle3.z = UnityEngine.Random.Range(-recoil, recoil);
        angle4.z = UnityEngine.Random.Range(-recoil, recoil);
        angle5.z = UnityEngine.Random.Range(-recoil, recoil);



        firePoint1.transform.localEulerAngles = new Vector3(0f, 0f, angle1.z);
        firePoint2.transform.localEulerAngles = new Vector3(0f, 0f, angle2.z);
        firePoint3.transform.localEulerAngles = new Vector3(0f, 0f, angle3.z);
        firePoint4.transform.localEulerAngles = new Vector3(0f, 0f, angle4.z);
        firePoint5.transform.localEulerAngles = new Vector3(0f, 0f, angle5.z);

        bulletForce1 = UnityEngine.Random.Range(minForce, maxForce);
        bulletForce2 = UnityEngine.Random.Range(minForce, maxForce);
        bulletForce3 = UnityEngine.Random.Range(minForce, maxForce);
        bulletForce4 = UnityEngine.Random.Range(minForce, maxForce);
        bulletForce5 = UnityEngine.Random.Range(minForce, maxForce);


        ammoDisplay.text = currentAmmo.ToString();
        clipSize.text = maxAmmo.ToString();

        if (isReloading)
            return;

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }



        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
        {
            nextTimeToFire = Time.time + 1f / fireRate;
            Shoot();

        }

        if (Input.GetKeyDown("r"))

        {
            StartCoroutine(Reload());

        }

    }

    public IEnumerator Reload()
    {
        isReloading = true;
        FindObjectOfType<AudioManager>().Play("Reload Effect");
        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isReloading = false;
    }

    void Shoot()
    {
        CinemachineShake.Instance.ShakeCamera(bulletScreenShake, .1f);

        GameObject bullet = Instantiate(bulletPrefab, firePoint1.position, firePoint1.rotation);
        GameObject bullet2 = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
        GameObject bullet3 = Instantiate(bulletPrefab, firePoint3.position, firePoint3.rotation);
        GameObject bullet4 = Instantiate(bulletPrefab, firePoint4.position, firePoint4.rotation);
        GameObject bullet5 = Instantiate(bulletPrefab, firePoint5.position, firePoint5.rotation);





        Rigidbody2D rb1 = bullet.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        Rigidbody2D rb3 = bullet3.GetComponent<Rigidbody2D>();
        Rigidbody2D rb4 = bullet4.GetComponent<Rigidbody2D>();
        Rigidbody2D rb5 = bullet5.GetComponent<Rigidbody2D>();
        rb1.AddForce(firePoint1.up * bulletForce1, ForceMode2D.Impulse);
        rb2.AddForce(firePoint2.up * bulletForce2, ForceMode2D.Impulse);
        rb3.AddForce(firePoint3.up * bulletForce3, ForceMode2D.Impulse);
        rb4.AddForce(firePoint4.up * bulletForce4, ForceMode2D.Impulse);
        rb5.AddForce(firePoint5.up * bulletForce5, ForceMode2D.Impulse);





        FindObjectOfType<AudioManager>().Play(shootSound);
        currentAmmo--;

    }






}