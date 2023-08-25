using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyMedkit : MonoBehaviour
{

    public int points;
    public GameObject button;
    public GameObject Medkit;
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



    }

    public void ButtonClick()
    {
        if (PointsSystem.currentScore >= points)
        {
            GameObject med = Instantiate(Medkit, spawnPoint.position, spawnPoint.rotation);
            Rigidbody2D rb = med.GetComponent<Rigidbody2D>();
            rb.AddForce(spawnPoint.up * exitForce, ForceMode2D.Impulse);
            FindObjectOfType<AudioManager>().Play(spawnSound);

            
            PointsSystem.currentScore -= points;
        }
    }
}