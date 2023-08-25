using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public string levelName;
    public int enemiesInRound = 75; // 50
    public int roundNumber;
    public GameObject playButton;
    public GameObject levelDecorations;

    public void playLevel ()
    {
        SceneManager.LoadScene(levelName);
        PauseMenu.GameIsPaused = false;
        EnemySpawner.enemiesTillNextRound = enemiesInRound; // enemiesInRound 
        EnemySpawner.enemiesOnScreen = 0; //
        PlayerMovement.roundCounter = roundNumber;

        if (roundNumber == 1)
        {
            FindObjectOfType<AudioManager>().Play("Coin Pickup");
            PointsSystem.currentScore = 0;
            PlayerMovement.upgradeTokens = 0;
            EnemySpawner.enemiesTillNextRound = enemiesInRound;
        }

        if (roundNumber == 2)
        {
            PlayerMovement.willTeleport = true;
            FindObjectOfType<AudioManager>().Play("Coin Pickup");
            PointsSystem.currentScore = 650;
            PlayerMovement.upgradeTokens = 4;
            EnemySpawner.enemiesTillNextRound = 0;
        }

        if (roundNumber == 3)
        {
            PlayerMovement.willTeleport = true;
            FindObjectOfType<AudioManager>().Play("Coin Pickup");
            PointsSystem.currentScore = 650; // CHANGE
            PlayerMovement.upgradeTokens = 4; // CHANGE
            EnemySpawner.enemiesTillNextRound = 0;
        }

    }

    public void quitGame()
    {
        Application.Quit();
    }


    void Update ()
    {
        
        if (PlayerMovement.roundCounter < roundNumber)
        {
            playButton.SetActive(false);
            levelDecorations.SetActive(false);
        }
            
        
    }





}
