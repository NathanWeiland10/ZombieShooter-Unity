using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MedkitScript : MonoBehaviour
{

    public string pickupSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerMovement player = hitInfo.GetComponent<PlayerMovement>();
        if (player != null)
        {

            NumberOfMedkits.currentMedkits += 1;
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play(pickupSound);

        }


    }
}
