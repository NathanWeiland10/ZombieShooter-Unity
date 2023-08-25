using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyTotalHealthUpgrade : MonoBehaviour
{
    public Text costText;

    public int initialTokenCost;
    public GameObject button;
    public GameObject Upgrade;
    public Transform spawnPoint;
    public float exitForce = 20f;
    public string spawnSound;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        costText.text = (initialTokenCost.ToString() + "x");

    }

    public void ButtonClick()
    {
        if ((PlayerMovement.upgradeTokens) >= initialTokenCost)
        {

            GameObject upgrade = Instantiate(Upgrade, spawnPoint.position, spawnPoint.rotation);
            Rigidbody2D rb = upgrade.GetComponent<Rigidbody2D>();
            rb.AddForce(spawnPoint.up * exitForce, ForceMode2D.Impulse);
            FindObjectOfType<AudioManager>().Play(spawnSound);

            PlayerMovement.upgradeTokens -= initialTokenCost;
            initialTokenCost++;
        }
    }
}