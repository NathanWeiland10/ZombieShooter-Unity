using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class ShootingDual: MonoBehaviour
{

    public Transform firePoint;
    public Transform firePoint2;
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

    private Vector3 angle;
    private Vector3 angle2;

    public float bulletScreenShake = 4f;
    public float currentScreenShake;

    public int recoil;

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

        angle.z = UnityEngine.Random.Range(-recoil, recoil);
        angle2.z = UnityEngine.Random.Range(-recoil, recoil);
        firePoint.transform.localEulerAngles = new Vector3(0f, 0f, angle.z);
        firePoint2.transform.localEulerAngles = new Vector3(0f, 0f, angle2.z);


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
        GameObject bullet = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
        GameObject bullet2 = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = bullet2.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        rb2.AddForce(firePoint2.up * bulletForce, ForceMode2D.Impulse);
        FindObjectOfType<AudioManager>().Play(shootSound);
        currentAmmo--;

    }






}
