using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class RoundCounterSpawner : MonoBehaviour
{

    public GameObject allEnemySpawners;
    public Text roundBeginText;
    public bool round1, round2, round3, round4, round5;



    void Start()
    {
        roundBeginText.gameObject.SetActive(false);
        allEnemySpawners.SetActive(false);
    }


    void Update()
    {
        {
            if (PlayerMovement.roundCounter == 1 && round1)

            {
                allEnemySpawners.SetActive(true);
                roundBeginText.gameObject.SetActive(true);
            }
            else if (PlayerMovement.roundCounter == 2 && round2)
            {
                allEnemySpawners.SetActive(true);
                roundBeginText.gameObject.SetActive(true);
            }
            else if (PlayerMovement.roundCounter == 3 && round3)
            {
                EnemySpawner.maxEnemiesOnScreen = 40;
                allEnemySpawners.SetActive(true);
                roundBeginText.gameObject.SetActive(true);
            }
            else if (PlayerMovement.roundCounter == 4 && round4)
            {
                allEnemySpawners.SetActive(true);
                roundBeginText.gameObject.SetActive(true);
            }
            else if (PlayerMovement.roundCounter == 5 && round5)
            {
                allEnemySpawners.SetActive(true);
                roundBeginText.gameObject.SetActive(true);
            }



            if (PlayerMovement.roundCounter == 1)
                if (round2 || round3 || round4 || round5)
                {
                    {
                        allEnemySpawners.SetActive(false);
                        roundBeginText.gameObject.SetActive(false);
                    }
                }

            if (PlayerMovement.roundCounter == 2)
                if (round1 || round3 || round4 || round5)
                {
                    {
                        allEnemySpawners.SetActive(false);
                        roundBeginText.gameObject.SetActive(false);
                    }
                }

            if (PlayerMovement.roundCounter == 3)
                if (round2 || round1 || round4 || round5)
                {
                    {
                        allEnemySpawners.SetActive(false);
                        roundBeginText.gameObject.SetActive(false);
                    }
                }

            if (PlayerMovement.roundCounter == 4)
                if (round2 || round3 || round1 || round5)
                {
                    {
                        allEnemySpawners.SetActive(false);
                        roundBeginText.gameObject.SetActive(false);
                    }
                }

            if (PlayerMovement.roundCounter == 5)
                if (round2 || round3 || round4 || round1)
                {
                    {
                        allEnemySpawners.SetActive(false);
                        roundBeginText.gameObject.SetActive(false);
                    }
                }




        }


            
        }
    }