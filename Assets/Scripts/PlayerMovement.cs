using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    
    

    public GameObject nextRoundButton;

    public GameObject miniMap;
    public int miniMapCost;
    public GameObject miniMapCanvas;
    public GameObject playerTransform;
    public GameObject spawnAreaTransform;
    public GameObject spawnAreaNextRoundTransform;

    public float moveSpeed = 5f;
    public double playerhealth = 100;
    public double maxplayerhealth = 100;
    public GameObject gameOverText, restartButton, bloodEffect;
    public Rigidbody2D rb;
    public Camera cam;
    public bool canLook = true;
    public float movementBoost = 1f;

    public static int upgradeTokens = 0;

    public Text currentHealthText;
    public Text maxHealthText;

    Vector2 movement;
    Vector2 mousePos;


    private float roundTeleportTimer = 0f;
    private bool countdownBegin = false;
    public Text roundCountdownText;
    private static float roundTeleportLength = 5f;


    private float nextRoundTeleportTimer = 0f;

    private bool nextRoundCountDown = false;
    public Text nextRoundCountDownText;
    private static float nextRoundTeleportLength = 5f;

    [System.NonSerialized]
    public float coolDownTimer;

    [System.NonSerialized]
    public int healthPerSecond;

    [System.NonSerialized]
    public static bool hasBeatenLevel1, hasBeatenLevel2, hasBeatenLevel3, hasBeatenLevel4, hasBeatenLevel5 = false;

    [System.NonSerialized]
    public static int roundCounter = 1; // 1

    [System.NonSerialized]
    public static bool newRound;

    [System.NonSerialized]
    public static bool willTeleport = false;

    [System.NonSerialized]
    public static bool hasTeleported;

    void Start()
    {
        newRound = false;
        countdownBegin = false;
        nextRoundButton.SetActive(false);
        miniMap.SetActive(false);
        roundTeleportTimer = roundTeleportLength;
        roundCountdownText.gameObject.SetActive(false);
        nextRoundCountDownText.gameObject.SetActive(false);
        hasTeleported = false;
        // upgradeTokens = 0; Needed to change due to button screen from menu, start with coins and points
        gameOverText.SetActive(false);
        restartButton.SetActive(false);
        Time.timeScale = 1f;
}


    public void ButtonClick()
    {
        if (upgradeTokens >= miniMapCost)
        {
            miniMap.SetActive(true);
            miniMap.SetActive(true);
            FindObjectOfType<AudioManager>().Play("Buy Effect");
            upgradeTokens -= miniMapCost;
            Destroy(miniMapCanvas);
        }
    }

    public void ButtonClickNextRound()
    {
        nextRoundCountDown = true;
        nextRoundButton.SetActive(false);
        roundCounter++;

        if (roundCounter == 2)
        {
            hasBeatenLevel1 = true;
        }
        if (roundCounter == 3)
        {
            hasBeatenLevel2 = true;
        }
        if (roundCounter == 4)
        {
            hasBeatenLevel3 = true;
        }
        if (roundCounter == 5)
        {
            hasBeatenLevel4 = true;
        }
        if (roundCounter == 6)
        {
            hasBeatenLevel5 = true;
        }
    }

    public void PlayerTakeDamage(int playerdamage)
    {
        playerhealth -= playerdamage;

        if (playerhealth <= 0)
        {
            Time.timeScale = 0f;
            gameOverText.SetActive(true);
            restartButton.SetActive(true);
            Instantiate(bloodEffect, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }



    }


    void Update()
    {

        if (!nextRoundCountDown)
        {
            nextRoundTeleportTimer = 5f;
        }
        

        if (nextRoundTeleportTimer > 0 && nextRoundCountDown)
        {
            nextRoundCountDownText.gameObject.SetActive(true);
            nextRoundTeleportTimer -= Time.deltaTime;
            double result = (Math.Round(nextRoundTeleportTimer * 10)) / 10.0;
            nextRoundCountDownText.text = "Next round in: " + result;
        }


           

            if (nextRoundTeleportTimer <= 0)
            {
                rb.rotation = 0;
                newRound = true;
                nextRoundCountDown = false;
                playerTransform.transform.position = new Vector3 (0, 0, 0); // spawnAreaNextRoundTransform.transform.position;
                nextRoundCountDownText.gameObject.SetActive(false);
                nextRoundTeleportTimer = nextRoundTeleportLength;
                nextRoundButton.SetActive(false);

            willTeleport = false;

            nextRoundTeleportTimer = 5f;

                EnemySpawner.enemiesTillNextRound = 50;



            }
        
  



        if (coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;
        }

        if (coolDownTimer <= 0)
        {
            if (playerhealth < maxplayerhealth)
            {
                playerhealth += healthPerSecond;
                coolDownTimer = 3f;
            }
        }

        if (playerhealth >= maxplayerhealth)
        {
            playerhealth = maxplayerhealth;
        }

        if (roundTeleportTimer > 0 && countdownBegin)
        {
            roundCountdownText.gameObject.SetActive(true);
            roundTeleportTimer -= Time.deltaTime;
            double result = (Math.Round(roundTeleportTimer*10)) / 10.0;
            roundCountdownText.text = "Teleporting in: " + result;
        }

        if (roundTeleportTimer <= 0)
        {
            countdownBegin = false;
            playerTransform.transform.position = spawnAreaTransform.transform.position;
            hasTeleported = true;
            roundCountdownText.gameObject.SetActive(false);
            roundTeleportTimer = roundTeleportLength;
            nextRoundButton.SetActive(true);
        }


        currentHealthText.text = playerhealth.ToString();
        maxHealthText.text = maxplayerhealth.ToString();


        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (EnemySpawner.enemiesTillNextRound == 0  && EnemySpawner.enemiesOnScreen == 0 && !hasTeleported)
        {
            countdownBegin = true;
        }

    }



    void FixedUpdate()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime * movementBoost);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

    private void OnTriggerStay2D(Collider2D hitInfo)
    {
        StopMouseLook stop = hitInfo.GetComponent<StopMouseLook>();
        if (stop != null)
        {
            transform.rotation = Quaternion.identity;
        }


    }


    public double getCurrentHealth() {
        return playerhealth;
     }

    public double getMaxHealth()
    {
        return maxplayerhealth;
;
    }



}