using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusBar : MonoBehaviour
{
    public PlayerMovement Player;
    public Image fillImage;
    private Slider slider;
    public string criticalHealth;

    private bool critical = false;


    // Start is called before the first frame update
    void Awake()
    {

        slider = GetComponent<Slider>();
        slider.maxValue = (float)Player.maxplayerhealth / 100;
        slider.minValue = 0;
        slider.value = slider.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        // slider.maxValue = Player.maxplayerhealth;

        float fillValue = (float)Player.getCurrentHealth() / (float)Player.getMaxHealth();
        slider.value = fillValue;

        if (critical)
            return;


        if (slider.value <= slider.minValue)
        {
            Destroy(this.gameObject);
        }

        if (fillValue <= slider.maxValue * 1.0)
        {
            fillImage.color = Color.green;
        }

        if (fillValue <= slider.maxValue * 0.7)
        {
            fillImage.color = Color.yellow;
        }

        if (fillValue <= slider.maxValue * 0.4)
        {
            fillImage.color = Color.red;
        }

        if (fillValue <= slider.maxValue * 0.2)
        {
            critical = true;
            fillImage.color = Color.red;
            StartCoroutine(NeedHealth());

        }

      

    }
    IEnumerator NeedHealth()
    {
        
        fillImage.color = Color.white;
        FindObjectOfType<AudioManager>().Play(criticalHealth);
        yield return new WaitForSeconds(0.1f);
        fillImage.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        FindObjectOfType<AudioManager>().Play(criticalHealth);
        fillImage.color = Color.white;
        yield return new WaitForSeconds(0.1f);
        fillImage.color = Color.red;
        yield return new WaitForSeconds(1f);
        fillImage.color = Color.white;
        critical = false;
      
    }
}
