using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class RobotRocket : MonoBehaviour
{
    public GameObject hitBox;
    public ParticleSystem explosionEffect;
    public int damageToPlayer = 0;
    public string explosionSound;
    public ParticleSystem bloodEffect;
    public ParticleSystem deathEffect;
    public string playerHurtSound;




  

    void OnTriggerEnter2D(Collider2D hitInfo)
    {


        PlayerMovement player = hitInfo.GetComponent<PlayerMovement>();
        if (player != null)
        {
            player.PlayerTakeDamage(damageToPlayer);
            Instantiate(bloodEffect, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play(playerHurtSound);
            Instantiate(explosionEffect, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play(explosionSound);
            StartCoroutine(HitBox());
            Destroy(gameObject);
        }

        SolidTiles solid = hitInfo.GetComponent<SolidTiles>();
        if (solid != null)
        {
            Instantiate(explosionEffect, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play(explosionSound);
            Destroy(gameObject);
            StartCoroutine(HitBox());
        }

    }

   

    IEnumerator HitBox()
    {
        Instantiate(hitBox, transform.position, transform.rotation);
        yield return new WaitForSeconds(0.01f);
        Destroy(hitBox);
    }

}
