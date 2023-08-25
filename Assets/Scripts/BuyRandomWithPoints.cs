using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class BuyRandomWithPoints : MonoBehaviour
{
    private int RandomWeapon;
    public int points;
    public GameObject button;
    public Transform spawnPoint;
    public float exitForce = 20f;
    public string spawnSound;

    
    public GameObject BarrettM82;
    public GameObject Crossbow;
    public GameObject DualG18;
    public GameObject GrenadeLauncher;
    public GameObject M60;
    public GameObject NerfGun;
    public GameObject Revolver;
    
    

    List<GameObject> weaponList = new List<GameObject>{};
    private int weaponCounter = 0;


    private static Random rng = new Random();


// Start is called before the first frame update
void Start()
    {

        weaponList.Add(BarrettM82);
        weaponList.Add(Crossbow);
        weaponList.Add(DualG18);
        weaponList.Add(GrenadeLauncher);
        weaponList.Add(M60);
        weaponList.Add(NerfGun);
        weaponList.Add(Revolver);

        weaponList.Shuffle();

    }




    // Update is called once per frame
    void Update()
    {

       

    }

    public void ButtonClick()
    {

        weaponCounter++;

        if (PointsSystem.currentScore >= points && weaponCounter == 1)
        {
           
            {
                GameObject weapon = Instantiate(weaponList[0], spawnPoint.position, spawnPoint.rotation);
                Rigidbody2D rb = weapon.GetComponent<Rigidbody2D>();
                rb.AddForce(spawnPoint.up * exitForce, ForceMode2D.Impulse);
                FindObjectOfType<AudioManager>().Play(spawnSound);
                PointsSystem.currentScore -= points;
                
            }
        }
        if (PointsSystem.currentScore >= points && weaponCounter == 2)
        {
            
            {
                GameObject med = Instantiate(weaponList[1], spawnPoint.position, spawnPoint.rotation);
                Rigidbody2D rb = med.GetComponent<Rigidbody2D>();
                rb.AddForce(spawnPoint.up * exitForce, ForceMode2D.Impulse);
                FindObjectOfType<AudioManager>().Play(spawnSound);
                PointsSystem.currentScore -= points;
                
            }
        }
        if (PointsSystem.currentScore >= points && weaponCounter == 3)
        {
            
            {
                GameObject med = Instantiate(weaponList[2], spawnPoint.position, spawnPoint.rotation);
                Rigidbody2D rb = med.GetComponent<Rigidbody2D>();
                rb.AddForce(spawnPoint.up * exitForce, ForceMode2D.Impulse);
                FindObjectOfType<AudioManager>().Play(spawnSound);
                PointsSystem.currentScore -= points;
               
            }
        }
        if (PointsSystem.currentScore >= points && weaponCounter == 4)
        {
           
            {
                GameObject med = Instantiate(weaponList[3], spawnPoint.position, spawnPoint.rotation);
                Rigidbody2D rb = med.GetComponent<Rigidbody2D>();
                rb.AddForce(spawnPoint.up * exitForce, ForceMode2D.Impulse);
                FindObjectOfType<AudioManager>().Play(spawnSound);
                PointsSystem.currentScore -= points;
               
            }
        }
        if (PointsSystem.currentScore >= points && weaponCounter == 5)
        {
            
            {
                GameObject med = Instantiate(weaponList[4], spawnPoint.position, spawnPoint.rotation);
                Rigidbody2D rb = med.GetComponent<Rigidbody2D>();
                rb.AddForce(spawnPoint.up * exitForce, ForceMode2D.Impulse);
                FindObjectOfType<AudioManager>().Play(spawnSound);
                PointsSystem.currentScore -= points;
               
            }
        }
        if (PointsSystem.currentScore >= points && weaponCounter == 6)
        {
            
            {
                GameObject med = Instantiate(weaponList[5], spawnPoint.position, spawnPoint.rotation);
                Rigidbody2D rb = med.GetComponent<Rigidbody2D>();
                rb.AddForce(spawnPoint.up * exitForce, ForceMode2D.Impulse);
                FindObjectOfType<AudioManager>().Play(spawnSound);
                PointsSystem.currentScore -= points;
               
            }
        }
        if (PointsSystem.currentScore >= points && weaponCounter == 7)
        {
            
            {
                GameObject med = Instantiate(weaponList[6], spawnPoint.position, spawnPoint.rotation);
                Rigidbody2D rb = med.GetComponent<Rigidbody2D>();
                rb.AddForce(spawnPoint.up * exitForce, ForceMode2D.Impulse);
                FindObjectOfType<AudioManager>().Play("Still Healing");
                PointsSystem.currentScore -= points;

                Destroy(this.gameObject);

            }
        }
    }


    

}




static class MyExtensions
{




    private static System.Random rng = new System.Random();

    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
