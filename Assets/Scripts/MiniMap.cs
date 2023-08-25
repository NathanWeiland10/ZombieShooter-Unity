using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMap : MonoBehaviour
{

    public Transform player;

   

    void LateUpdate ()
    {
        Vector3 newPosition = new Vector3(player.position.x, player.position.y, -30);
        transform.position = newPosition;
    }

}
