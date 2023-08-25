using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using Cinemachine;

public class Shooting : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    
    public float fireRate = 15f;
    private float nextTimeToFire = 0f;
    public float bulletScreenShake = 4f;
    public float currentScreenShake;


    Vector2 movement;
    public int maxAmmo = 8;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;
    public string shootSound;

    public Text ammoDisplay;
    public Text clipSize;

    private Vector3 angle;

    public int recoil;

    void Start ()
    {    
        currentAmmo = maxAmmo;   
    }

    void OnEnable ()
    {
        isReloading = false;
    }
  
    void Update()
    {
        currentScreenShake = bulletScreenShake;
        
       
        angle.z = UnityEngine.Random.Range(-recoil, recoil);
        ammoDisplay.text = currentAmmo.ToString();
        clipSize.text = maxAmmo.ToString();

        if (isReloading)
            return;

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }



        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && !PauseMenu.GameIsPaused)
        {
            
            nextTimeToFire = Time.time + 1f / fireRate;
            
            Shoot();

        }

        if (Input.GetKeyDown("r"))
            
                
        {

            if (!PauseMenu.GameIsPaused)
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
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        FindObjectOfType<AudioManager>().Play(shootSound);
        currentAmmo--;

    }



    


}
