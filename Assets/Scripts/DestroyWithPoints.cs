using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyWithPoints : MonoBehaviour
{

    public int points;
    public GameObject button;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        


    }

    public void ButtonClick ()
    {
        if (PointsSystem.currentScore >= points)
        {
            Destroy(gameObject);
            PointsSystem.currentScore -= points;
            button.SetActive(false);

        }
    }
}
