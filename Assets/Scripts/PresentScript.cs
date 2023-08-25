using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PresentScript : MonoBehaviour
{

    public Transform spawnPoint;
    public GameObject present1;
    public GameObject present2;
    public GameObject present3;
    public GameObject present4;
    public GameObject present5;
    public string spawnSoundEffect;
    private int itemChosen = 0;



    void Start()
    {
        itemChosen = UnityEngine.Random.Range(1, 6);
    }

    
    void Update()
    {
        
    }





    private void OnTriggerStay2D(Collider2D hitInfo)
    {
        PlayerMovement player = hitInfo.GetComponent<PlayerMovement>();
        if (player != null)

            itemChosen = UnityEngine.Random.Range(1, 5);

             if (itemChosen == 1)
            {
                Instantiate(present1, spawnPoint.position, spawnPoint.rotation);
            } else if (itemChosen == 2)
            {
                Instantiate(present2, spawnPoint.position, spawnPoint.rotation);
            } else if (itemChosen == 3)
            {
                Instantiate(present3, spawnPoint.position, spawnPoint.rotation);
            } else if (itemChosen == 4)
            {
                Instantiate(present4, spawnPoint.position, spawnPoint.rotation);
            } else if (itemChosen == 5)
            {
                Instantiate(present5, spawnPoint.position, spawnPoint.rotation);
            } 


                FindObjectOfType<AudioManager>().Play(spawnSoundEffect);
                Destroy(gameObject);

         }
    }



