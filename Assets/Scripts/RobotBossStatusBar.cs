using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RobotBossStatusBar : MonoBehaviour
{
    public RobotBoss robotBoss;
    public Image fillImage;
    private Slider slider;


    // Start is called before the first frame update
    void Awake()
    {

        slider = GetComponent<Slider>();

    }

    // Update is called once per frame
    void Update()
    {

        float fillValue = (float)robotBoss.health / 10f;
        slider.value = fillValue;

        if (slider.value <= slider.minValue)
        {

            Destroy(this.gameObject);
        }


    }
}
