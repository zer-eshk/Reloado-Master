using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    public float speed = 1f;
    private Rigidbody2D rb;
    private Transform target;
    Vector2 moveDir;
    // Start is called before the first frame update
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDir = direction;
            float rotz = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = rotz;
        }

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDir.x, moveDir.y) * speed;
    }
}
