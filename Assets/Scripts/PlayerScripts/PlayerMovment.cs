using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovment : MonoBehaviour
{
    public float moveSpeed_shoot;
    public float moveSpeed = 1f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    [SerializeField] float isshoitng;
    [SerializeField] bool isReloading;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Shoting shoting = GetComponent<Shoting>();
        if (shoting != null)
        {
            isshoitng = shoting.isShoting;
            isReloading=shoting.isReloading;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       if(isshoitng>0&& isReloading==false)
        {
            rb.velocity = moveInput * moveSpeed_shoot;
        }
       else { rb.velocity = moveInput * moveSpeed; }
       
    }
    public void Move(InputAction.CallbackContext context)

    {
        moveInput=context.ReadValue<Vector2>();
    }
}
