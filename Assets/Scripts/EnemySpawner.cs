using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    [System.NonSerialized]
    static public int enemiesOnScreen = 0;

    public bool enemiesRound1, enemiesRound2, enemiesRound3;

    static public int maxEnemiesOnScreen = 20; // 20
    static public int enemiesTillNextRound1 = 50; // 50
    static public int enemiesTillNextRound2 = 75; // 75
    public Transform spawnPosition;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    float nextSpawn = 0.0f;
    public float minSpawnTime = 3f;
    public float maxSpawnTime = 7f;
    [SerializeField]
    Vector2 v2spawnPosJitter;

    private float coolDownTimer;
    private int zombieChosen = 0;

    [System.NonSerialized]
    static public int enemiesTillNextRound;

    // Start is called before the first frame update
    void Awake ()
    {
        if (enemiesRound1)
        {
            enemiesTillNextRound = enemiesTillNextRound1;
        }

        if (enemiesRound2)
        {
            enemiesTillNextRound = enemiesTillNextRound2;
        }

    }

    // Update is called once per frame
    void Update()
    {


        if (coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
        }

        if (coolDownTimer <= 0)
        {
            zombieChosen = UnityEngine.Random.Range(1, 4);
            nextSpawn = UnityEngine.Random.Range(1f, 10f);
            coolDownTimer = UnityEngine.Random.Range(minSpawnTime, maxSpawnTime);
            if (enemiesOnScreen < maxEnemiesOnScreen && enemiesTillNextRound > 0) {
                PlayerMovement.hasTeleported = false;
                enemiesTillNextRound--;
                enemiesOnScreen++;
                spawn();
                
            }
        }


    }

    void spawn()
    {
        Vector2 v2spawnPos = transform.position;
        v2spawnPos += Vector2.up * v2spawnPosJitter.x * (UnityEngine.Random.Range(-5f, 5f));
        v2spawnPos += Vector2.right * v2spawnPosJitter.y * (UnityEngine.Random.Range(-5f, 5f));

        if (zombieChosen == 1)
        {
            Instantiate(enemy1, v2spawnPos, Quaternion.identity);
        } else if (zombieChosen == 2)
        {
            Instantiate(enemy2, v2spawnPos, Quaternion.identity);
        } else if (zombieChosen == 3)
        {
            Instantiate(enemy3, v2spawnPos, Quaternion.identity);
        }
         
    }

   
}
