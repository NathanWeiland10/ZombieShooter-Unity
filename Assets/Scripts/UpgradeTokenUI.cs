using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpgradeTokenUI : MonoBehaviour
{

    public Text amountOfTokensText;

    // Update is called once per frame
    void Update()
    {
        amountOfTokensText.text = (PlayerMovement.upgradeTokens.ToString() + "x");
    }
}
