using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalHealthUpgradePickup : MonoBehaviour
{

    public string pickupSound;
    public int upgradeAmount;
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
            player.maxplayerhealth += upgradeAmount;
            player.playerhealth = player.maxplayerhealth;
            FindObjectOfType<AudioManager>().Play(pickupSound);
            Instantiate(pickupCanvas, upgradeTransform.position, upgradeTransform.rotation);
        }


    }




}