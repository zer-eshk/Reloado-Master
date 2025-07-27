using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Transform target;
    private Rigidbody2D rb;
    Vector2 moveDir;
    public float bulletSpeed = 5;
    public float bulletLifeTime = 5;
    public int bulletDamage;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        Destroy(gameObject, bulletLifeTime);
        target = GameObject.Find("Player").transform;
        Vector3 direction = (target.position - transform.position).normalized;
        moveDir = direction;
        float rotz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = rotz;

        rb.velocity = new Vector2(moveDir.x, moveDir.y) * bulletSpeed;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {


            Destroy(gameObject);
        }
    }


}
