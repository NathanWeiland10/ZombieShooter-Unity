using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemiesTillNextRoundUI: MonoBehaviour
{

    public Text enemiesTillNextRound;


    void Start()
    {

    }

    void Update()
    {

        enemiesTillNextRound.text = ("Until Next Round: ") + EnemySpawner.enemiesTillNextRound.ToString();

    }


}