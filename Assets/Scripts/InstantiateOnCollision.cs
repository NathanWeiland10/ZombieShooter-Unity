using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateOnCollision : MonoBehaviour
{
    public Transform transTarget;

    public Rigidbody2D rb;
    public GameObject goSpawnM4;
    public GameObject goSpawnUzi;
    public GameObject goSpawnShotgun;
    public GameObject goSpawnRPG;
    public GameObject goSpawnBarrettM82;
    public GameObject goSpawnCrossbow;
    public GameObject goSpawnDualG18;
    public GameObject goSpawnGrenadeLauncher;
    public GameObject goSpawnM60;
    public GameObject goSpawnNerfGun;
    public GameObject goSpawnRevolver;
    public string soundEffect;

    private bool isDisabled;


    void Start()
    {
        goSpawnM4.active = false;
        goSpawnUzi.active = false;
        goSpawnShotgun.active = false;
        goSpawnRPG.active = false;
        goSpawnBarrettM82.active = false;
        goSpawnCrossbow.active = false;
        goSpawnDualG18.active = false;
        goSpawnGrenadeLauncher.active = false;
        goSpawnM60.active = false;
        goSpawnNerfGun.active = false;
        goSpawnRevolver.active = false;

    }

    void OnEnable()
    {

        transform.position = transTarget.position;
        isDisabled = false;
        goSpawnM4.active = false;
        goSpawnUzi.active = false;
        goSpawnShotgun.active = false;
        goSpawnRPG.active = false;
        goSpawnBarrettM82.active = false;
        goSpawnCrossbow.active = false;
        goSpawnDualG18.active = false;
        goSpawnGrenadeLauncher.active = false;
        goSpawnM60.active = false;
        goSpawnNerfGun.active = false;
        goSpawnRevolver.active = false;
    }

    


    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        

        GroundM4 M4 = hitInfo.GetComponent<GroundM4>();
        if (M4 != null)
        {
            goSpawnM4.transform.parent = gameObject.transform;
            transform.position = transTarget.position;
          
            goSpawnM4.active = false;
            transform.rotation = transTarget.rotation;
            FindObjectOfType<AudioManager>().Play(soundEffect);
        }
        GroundUzi Uzi = hitInfo.GetComponent<GroundUzi>();
        if (Uzi != null)
        {
            goSpawnUzi.transform.parent = gameObject.transform;
            transform.position = transTarget.position;
           
            goSpawnUzi.active = false;
            transform.rotation = transTarget.rotation;
            FindObjectOfType<AudioManager>().Play(soundEffect);

        }
        GroundShotgun Shotgun = hitInfo.GetComponent<GroundShotgun>();
        if (Shotgun != null)
        {
            goSpawnShotgun.transform.parent = gameObject.transform;
            transform.position = transTarget.position;
           
            goSpawnShotgun.active = false;
            transform.rotation = transTarget.rotation;
            FindObjectOfType<AudioManager>().Play(soundEffect);
        }
        GroundRPG RPG = hitInfo.GetComponent<GroundRPG>();
        if (RPG != null)
        {
            goSpawnRPG.transform.parent = gameObject.transform;
            transform.position = transTarget.position;
           
            goSpawnRPG.active = false;
            transform.rotation = transTarget.rotation;
            FindObjectOfType<AudioManager>().Play(soundEffect);
        }
        GroundBarrettM82 BarrettM82 = hitInfo.GetComponent<GroundBarrettM82>();
        if (BarrettM82 != null)
        {
            goSpawnBarrettM82.transform.parent = gameObject.transform;
            transform.position = transTarget.position;

            goSpawnBarrettM82.active = false;
            transform.rotation = transTarget.rotation;
            FindObjectOfType<AudioManager>().Play(soundEffect);
        }
        GroundCrossbow Crossbow = hitInfo.GetComponent<GroundCrossbow>();
        if (Crossbow != null)
        {
            goSpawnCrossbow.transform.parent = gameObject.transform;
            transform.position = transTarget.position;

            goSpawnCrossbow.active = false;
            transform.rotation = transTarget.rotation;
            FindObjectOfType<AudioManager>().Play(soundEffect);
        }
        GroundDualG18 DualG18 = hitInfo.GetComponent<GroundDualG18>();
        if (DualG18 != null)
        {
            goSpawnDualG18.transform.parent = gameObject.transform;
            transform.position = transTarget.position;

            goSpawnDualG18.active = false;
            transform.rotation = transTarget.rotation;
            FindObjectOfType<AudioManager>().Play(soundEffect);
        }
        GroundGrenadeLauncher GrenadeLauncher = hitInfo.GetComponent<GroundGrenadeLauncher>();
        if (GrenadeLauncher != null)
        {
            goSpawnGrenadeLauncher.transform.parent = gameObject.transform;
            transform.position = transTarget.position;

            goSpawnGrenadeLauncher.active = false;
            transform.rotation = transTarget.rotation;
            FindObjectOfType<AudioManager>().Play(soundEffect);
        }
        GroundM60 M60 = hitInfo.GetComponent<GroundM60>();
        if (M60 != null)
        {
            goSpawnM60.transform.parent = gameObject.transform;
            transform.position = transTarget.position;

            goSpawnM60.active = false;
            transform.rotation = transTarget.rotation;
            FindObjectOfType<AudioManager>().Play(soundEffect);
        }
        GroundNerfGun NerfGun = hitInfo.GetComponent<GroundNerfGun>();
        if (NerfGun != null)
        {
            goSpawnNerfGun.transform.parent = gameObject.transform;
            transform.position = transTarget.position;

            goSpawnNerfGun.active = false;
            transform.rotation = transTarget.rotation;
            FindObjectOfType<AudioManager>().Play(soundEffect);
        }
        GroundRevolver Revolver = hitInfo.GetComponent<GroundRevolver>();
        if (Revolver != null)
        {
            goSpawnRevolver.transform.parent = gameObject.transform;
            transform.position = transTarget.position;

            goSpawnRevolver.active = false;
            transform.rotation = transTarget.rotation;
            FindObjectOfType<AudioManager>().Play(soundEffect);
        }
    }
    void Update()
    {

        transform.position = transTarget.position;


    }
}
