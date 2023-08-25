using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class WeaponSwitching : MonoBehaviour
{
    public int selectedWeapon = 0;
    bool isReloading = false;

    public Shooting shootingScriptPistol;
    public GameObject Pistol;

    public Shooting shootingScriptM4;
    public GameObject M4;

    public Shooting shootingScriptUzi;
    public GameObject Uzi;

    public ShootingShotgun shootingScriptShotgun;
    public GameObject Shotgun;

    public Shooting shootingScriptRPG;
    public GameObject RPG;

    public Shooting shootingScriptBarrettM82;
    public GameObject BarrettM82;

    public Shooting shootingScriptCrossbow;
    public GameObject Crossbow;

    public ShootingDual shootingScriptDualG18;
    public GameObject DualG18;

    public Shooting shootingScriptGrenadeLauncher;
    public GameObject GrenadeLauncher;

    public Shooting shootingScriptM60;
    public GameObject M60;

    public Shooting shootingScriptNerfGun;
    public GameObject NerfGun;

    public Shooting shootingScriptRevolver;
    public GameObject Revolver;

    public List<GameObject> allWeaponsList;

    public List<GameObject> currentWeaponsList;



    void Start()
    {
        SelectWeapon();
    }

    void Awake()
    {
        
    }

    
    public void addWeaponToList(GameObject g)
    {
        currentWeaponsList.Add(g);
    }


    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;
        
        

        if (isReloading)
            return;

        {

            if (Input.GetKeyDown("r"))
            {
                if (Pistol.activeSelf == (true))
                    StartCoroutine(ReloadPistol());
                isReloading = true;

                if (M4.activeSelf == (true))
                    StartCoroutine(ReloadM4());
                isReloading = true;

                if (Uzi.activeSelf == (true))
                    StartCoroutine(ReloadUzi());
                isReloading = true;

                if (Shotgun.activeSelf == (true))
                    StartCoroutine(ReloadShotgun());
                isReloading = true;

                if (RPG.activeSelf == (true))
                    StartCoroutine(ReloadRPG());
                isReloading = true;

                if (BarrettM82.activeSelf == (true))
                    StartCoroutine(ReloadBarrettM82());
                isReloading = true;

                if (Crossbow.activeSelf == (true))
                    StartCoroutine(ReloadCrossbow());
                isReloading = true;

                if (DualG18.activeSelf == (true))
                    StartCoroutine(ReloadDualG18());
                isReloading = true;

                if (GrenadeLauncher.activeSelf == (true))
                    StartCoroutine(ReloadGrenadeLauncher());
                isReloading = true;

                if (M60.activeSelf == (true))
                    StartCoroutine(ReloadM60());
                isReloading = true;

                if (NerfGun.activeSelf == (true))
                    StartCoroutine(ReloadNerfGun());
                isReloading = true;

                if (Revolver.activeSelf == (true))
                    StartCoroutine(ReloadRevolver());
                isReloading = true;

            }

            if (!PauseMenu.GameIsPaused)
            

                if (Input.GetAxis("Mouse ScrollWheel") > 0f)
                {

                    if (selectedWeapon >= currentWeaponsList.Count - 1)
                        selectedWeapon = 0;
                    else
                        selectedWeapon++;
                }


            if (!PauseMenu.GameIsPaused)


                if (Input.GetAxis("Mouse ScrollWheel") < 0f)
                {
                    if (selectedWeapon <= 0)
                        selectedWeapon = currentWeaponsList.Count - 1;
                    else
                        selectedWeapon--;
                }

                if (previousSelectedWeapon != selectedWeapon)
                {

                    SelectWeapon();

                }

            
        }
    }


    IEnumerator ReloadPistol()
    {
        isReloading = true;
        yield return new WaitForSeconds(shootingScriptPistol.reloadTime);
        isReloading = false;
    }

    IEnumerator ReloadM4()
    {
        isReloading = true;
        yield return new WaitForSeconds(shootingScriptM4.reloadTime);
        isReloading = false;
    }

    IEnumerator ReloadUzi()
    {
        isReloading = true;
        yield return new WaitForSeconds(shootingScriptUzi.reloadTime);
        isReloading = false;
    }

    IEnumerator ReloadShotgun()
    {
        isReloading = true;
        yield return new WaitForSeconds(shootingScriptShotgun.reloadTime);
        isReloading = false;
    }

    IEnumerator ReloadRPG()
    {
        isReloading = true;
        yield return new WaitForSeconds(shootingScriptRPG.reloadTime);
        isReloading = false;
    }

    IEnumerator ReloadBarrettM82()
    {
        isReloading = true;
        yield return new WaitForSeconds(shootingScriptRPG.reloadTime);
        isReloading = false;
    }

    IEnumerator ReloadCrossbow()
    {
        isReloading = true;
        yield return new WaitForSeconds(shootingScriptRPG.reloadTime);
        isReloading = false;
    }

    IEnumerator ReloadDualG18()
    {
        isReloading = true;
        yield return new WaitForSeconds(shootingScriptRPG.reloadTime);
        isReloading = false;
    }

    IEnumerator ReloadGrenadeLauncher()
    {
        isReloading = true;
        yield return new WaitForSeconds(shootingScriptRPG.reloadTime);
        isReloading = false;
    }

    IEnumerator ReloadM60()
    {
        isReloading = true;
        yield return new WaitForSeconds(shootingScriptRPG.reloadTime);
        isReloading = false;
    }

    IEnumerator ReloadNerfGun()
    {
        isReloading = true;
        yield return new WaitForSeconds(shootingScriptRPG.reloadTime);
        isReloading = false;
    }

    IEnumerator ReloadRevolver()
    {
        isReloading = true;
        yield return new WaitForSeconds(shootingScriptRPG.reloadTime);
        isReloading = false;
    }



    void SelectWeapon ()
    {
      
      
        int i = 0;
            foreach (GameObject weapon in currentWeaponsList)
            {
                if (i == selectedWeapon)
                    weapon.gameObject.SetActive(true);
                else
                    weapon.gameObject.SetActive(false);
                i++;

           
            }
        }
    }



 