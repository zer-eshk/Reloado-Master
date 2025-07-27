using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHp : MonoBehaviour
{
    public int enemyHp=60;
    public int damageToPlayer = 50;
    

    public void TakeDamage(int damage)
    {
        enemyHp-=damage;
        if (enemyHp <= 0)
        {
            Destroy(gameObject);
        }
    }
    
}
