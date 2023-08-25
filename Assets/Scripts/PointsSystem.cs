using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PointsSystem : MonoBehaviour
{

    public Text scoreText;
    static public int currentScore;


    void Start ()
    {
        // currentScore = 0; Needed to change due to button screen from menu, start with coins and points
    }

    void Update ()
    {
   
        scoreText.text = ("Points: ") + currentScore.ToString();

    }

    
}
