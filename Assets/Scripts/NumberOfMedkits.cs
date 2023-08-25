using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class NumberOfMedkits : MonoBehaviour
{

    public Text totalMedkits;
    public Text currentHealingLength;
    public GameObject icon;
    static public int currentMedkits;
    public float healLength = 10f;
    public PlayerMovement Player;
    public MedkitScript medKits;
    public string healingSound;
    public string healingComplete;
    public string stillHealing;
    private float coolDownTimer;



    // Start is called before the first frame update
    void Start()
    {
        currentMedkits = 0;
        GetComponent<PlayerMovement>();
        currentHealingLength.gameObject.SetActive(false);
        icon.gameObject.SetActive(false);
        totalMedkits.gameObject.SetActive(false);   
    }
   
    void Update()
    {
        currentHealingLength.text = ("Next Heal: ") + (coolDownTimer -= (1 * Time.deltaTime)).ToString(".0");
        totalMedkits.text = currentMedkits.ToString() + ("x");

       


        if (Input.GetKeyDown("e") && coolDownTimer > 0)
        {
            
        }

       

        if (coolDownTimer > 0)
        {
            coolDownTimer -= Time.deltaTime;

         
            {
               
                icon.gameObject.SetActive(false);
                totalMedkits.gameObject.SetActive(false);
                currentHealingLength.gameObject.SetActive(true);
            }
        }

        if (coolDownTimer <= 0)
        {
            coolDownTimer = 0;

           
                icon.gameObject.SetActive(true);
                totalMedkits.gameObject.SetActive(true);
                currentHealingLength.gameObject.SetActive(false);
            }
        


            if (currentMedkits > 0)
            {


            if (Input.GetKeyDown("e") && coolDownTimer == 0)
            {

               

                Player.playerhealth = Player.maxplayerhealth;
                coolDownTimer = healLength;
               
                currentMedkits--;
                FindObjectOfType<AudioManager>().Play(healingComplete);
            }

            if (Input.GetKeyDown("e") && coolDownTimer < (healLength - 1f))
            { 
                FindObjectOfType<AudioManager>().Play(stillHealing);
                return;
            }
        }
      
    }
}
