using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovment : MonoBehaviour
{
    PlayerControls controls;
    public GameObject DashUI;
    public float moveSpeed_shoot;
    public float moveSpeed = 1f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    [SerializeField] float isshoitng;
    [SerializeField] bool isReloading;
    [SerializeField] bool canDash = true;
    [SerializeField] TrailRenderer tr;
    private bool isDashing = false;
    public float dashPower;
    public float dashTime;
    public float dashCD;
    private void Awake()
    {
        if (gameObject != null)
        {
            controls = new PlayerControls();
            controls.Enable();
            controls.Player.Dash.performed += (ctx) =>
            {

                if (canDash == true && moveInput != Vector2.zero)
                {

                    StartCoroutine(Dash());



                }
            };


        }





    }

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<TrailRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Shoting shoting = GetComponent<Shoting>();
        if (shoting != null)
        {
            isshoitng = shoting.isShoting;
            isReloading = shoting.isReloading;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDashing)
        {
            return;

        }
        if (isshoitng > 0 && isReloading == false)
        {
            rb.velocity = moveInput * moveSpeed_shoot;
        }
        else { rb.velocity = moveInput * moveSpeed; }

    }
    public void Move(InputAction.CallbackContext context)

    {

        moveInput = context.ReadValue<Vector2>();

    }
    public IEnumerator Dash()
    {
        canDash = false;
        DashUI.SetActive(false);
        isDashing = true;
        tr.emitting = true;
        rb.velocity = new Vector2(moveInput.x, moveInput.y) * dashPower;
        yield return new WaitForSeconds(dashTime);
        tr.emitting = false;
        isDashing = false;
        yield return new WaitForSeconds(dashCD);
        DashUI.SetActive(true);
        canDash = true;

    }
}
