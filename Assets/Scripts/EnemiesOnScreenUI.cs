using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemiesOnScreenUI : MonoBehaviour
{

    public Text enemiesOnScreenText;


    void Start()
    {
        
    }

    void Update()
    {

        enemiesOnScreenText.text = ("Current Enemies: ") + EnemySpawner.enemiesOnScreen.ToString();

    }


}