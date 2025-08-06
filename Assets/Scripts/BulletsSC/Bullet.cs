using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeTime = 5f;
    public int bulletDamage = 20;
    public int activeBulletDamage;
    Rigidbody2D rb;
    public float orginalSpeed;
    public float bulletspeed;
    public float activeBulletSpeed;
    public TrailRenderer tr;
    public string normalBulletColor;
    public string activeBulletColor;

    


    void Start()
    {
        
        tr = GetComponent<TrailRenderer>();
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);
        rb.velocity = bulletspeed * transform.up;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {


            Destroy(gameObject);


        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyHp enemy = other.GetComponent<EnemyHp>();
            if (enemy != null)
            {
                enemy.TakeDamage(bulletDamage);
            }
            Destroy(gameObject);

        }
    }
}
