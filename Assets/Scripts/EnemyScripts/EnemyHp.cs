using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    public GameObject xpCrystal;
    public float enemyHp=60;
    public float damageToPlayer = 50;
    

    public void TakeDamage(float damage)
    {
        enemyHp-=damage;
        if (enemyHp <= 0)
        {
            Instantiate(xpCrystal, transform.position, Quaternion.Euler(0, 0, 90));
            Destroy(gameObject);
            
        }
    }
    
}
