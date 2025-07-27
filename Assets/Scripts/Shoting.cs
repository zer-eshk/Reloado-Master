using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shoting : MonoBehaviour
{
    PlayerControls controls;
    public GameObject fireBallPrefab;
    public Transform firePoint;
    public GameObject buletPrefab;
    public ActiveReload activeReloadSC;
    public int maxMana = 100;
    public int curentMana;
    public int fireBallManaCost = 50;
    public float orginalShotingCd = 0;
    public float activeShotingCd = 0;
    public float shotingCD = 0;
    public float shotingTimer = 0;
    public float isShoting;
    private float isShotingFireBall;
    public int maxAmmo = 10;
    public int curentAmmo;
    public bool isReloading = false;
    public float BarSpeed;
    public bool wasPerfectReload;
    Bullet bulletSc;
    GameObject newBullet;


    private void Awake()
    {


        if (gameObject != null)
        {
            controls = new PlayerControls();
            controls.Enable();
            controls.Player.FireBall.performed += (ctx) =>
            {
                FireBall();
            };

        }

    }
    // Start is called before the first frame update

    void Start()
    {
        
        //bullet.orginalSpeed=bullet.bulletspeed;
        orginalShotingCd = shotingCD;
        activeReloadSC.barSpeed = BarSpeed;
        curentMana = maxMana;
        curentAmmo = maxAmmo;


    }

    

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
        {
            return;
        }
        if (curentAmmo <= 0)
        {
            Reload();
            return;
        }
        Shoot();

    }
    public void ShootFireBall(InputAction.CallbackContext context)
    {
        isShotingFireBall = context.ReadValue<float>();
    }
    void FireBall()
    {

        if (isShotingFireBall > 0 && curentMana >= fireBallManaCost)
        {

            Instantiate(fireBallPrefab, firePoint.position, firePoint.rotation);
            curentMana -= fireBallManaCost;

        }
    }
    public void OnFire(InputAction.CallbackContext context)
    {
        isShoting = context.ReadValue<float>();
    }
    private void Shoot()
    {

        if (shotingTimer < shotingCD)
        {
            shotingTimer += Time.deltaTime;
            return;
        }


        if (isShoting > 0 && curentAmmo > 0)
        {

            newBullet = Instantiate(buletPrefab, firePoint.position, firePoint.rotation);
            curentAmmo--;
            shotingTimer = 0f;
            SpriteRenderer sr = newBullet.GetComponent<SpriteRenderer>();
            bulletSc=newBullet.GetComponent<Bullet>();

            
            if (wasPerfectReload)
            {
                sr.color = Color.black;
                bulletSc.bulletspeed=bulletSc.activeBulletSpeed;
                bulletSc.bulletDamage=bulletSc.activeBulletDamage;
            }
            else
            {

                sr.color = Color.yellow;
            }


        }





    }


    private void Reload()
    {
        activeReloadSC.StartReload();
    }
}





