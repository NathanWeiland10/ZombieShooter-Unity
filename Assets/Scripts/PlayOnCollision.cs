using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayOnCollision : MonoBehaviour
{
    public string soundname;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        PlayerMovement player = hitInfo.GetComponent<PlayerMovement>();
        if (player != null)
        {
            StartCoroutine(Play());
        }

       
        
    }
    IEnumerator Play()
    {
        FindObjectOfType<AudioManager>().Play(soundname);
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(false);
    }
}
