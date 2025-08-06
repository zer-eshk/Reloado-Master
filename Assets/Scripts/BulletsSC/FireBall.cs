using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float lifeTime = 30f;
    public float damage = 20;
    Rigidbody2D rb;
    public float bulletspeed = 10f;
   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
        rb.velocity = bulletspeed * transform.up;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (other.gameObject.CompareTag("Wall"))
            {


                Destroy(gameObject);


            }
            EnemyHp enemy = other.GetComponent<EnemyHp>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            

        }
    }

}
