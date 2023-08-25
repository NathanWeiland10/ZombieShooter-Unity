﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restartScene()
    {
        EnemySpawner.enemiesTillNextRound = 100;
        EnemySpawner.enemiesOnScreen = 0;
        SceneManager.LoadScene("Level1");
    }
}
