using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGHitBox : MonoBehaviour

{
    public int damage = 10;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
           
            PointsSystem.currentScore += 1;
            Destroy(gameObject);

        }


        RobotBoss boss1 = hitInfo.GetComponent<RobotBoss>();
        if (boss1 != null)
        {
            boss1.TakeDamage(damage);
           
            PointsSystem.currentScore += 1;
            Destroy(gameObject);
        }

        SolidTiles box = hitInfo.GetComponent<SolidTiles>();
        if (box != null)
        {

            Destroy(gameObject);
        }

    }

   
}
