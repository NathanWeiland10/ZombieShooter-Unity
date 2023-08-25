using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageUpgradePickup : MonoBehaviour
{

    public string pickupSound;
    public float upgradeAmountPercent;
    public Transform upgradeTransform;
    public GameObject pickupCanvas;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerMovement player = hitInfo.GetComponent<PlayerMovement>();
        if (player != null)
        {
            Destroy(gameObject);

            Bullet.additionalDamage += upgradeAmountPercent;
            GrenadeLauncherBullet.additionalDamage += upgradeAmountPercent;




            FindObjectOfType<AudioManager>().Play(pickupSound);
            Instantiate(pickupCanvas, upgradeTransform.position, upgradeTransform.rotation);
        }


    }




}
