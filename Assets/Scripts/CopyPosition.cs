using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyPosition : MonoBehaviour
{

    public Transform transTarget;


    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = transTarget.position;
        transform.rotation = transTarget.rotation;
    }
}
