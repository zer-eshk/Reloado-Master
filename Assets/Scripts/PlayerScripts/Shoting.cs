using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using ColorUtility = UnityEngine.ColorUtility;



public class Shoting : MonoBehaviour
{
    PlayerControls controls;
    private Bullet bullet;
    public GameObject fireBallPrefab;
    public GameObject freeCostSpellUi;
    public GameObject buletPrefab;
    GameObject newBullet;
    public Transform firePoint;
    public ActiveReload activeReloadSC;
    Bullet bulletSc;
    public FireBall fireBallSC;
    public PlayerStats playerStats;
    GameObject newFireBall;
    public int maxMana = 100;
    public int curentMana;
    public int fireBallManaCost = 50;
    public float orginalShotingCd = 0;
    public float activeShotingCd = 0;
    public float shotingCD = 0;
    public float shotingTimer = 0;
    public float isShoting;
    public int orginalMaxAmmo = 0;
    public int maxAmmo = 10;
    public int activeMaxAmmo = 10;
    public int curentAmmo;
    public float BarSpeed;
    public bool isReloading = false;
    public bool wasPerfectReload;






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
        bullet = GetComponent<Bullet>();
        orginalMaxAmmo = maxAmmo;
        orginalShotingCd = shotingCD;
        activeReloadSC.barSpeed = BarSpeed;
        curentMana = maxMana;
        curentAmmo = maxAmmo;


    }



    // Update is called once per frame
    void Update()
    {

        if (shotingTimer < shotingCD)
        {
            shotingTimer += Time.deltaTime;
            return;
        }
        Shoot();

    }

    void FireBall()

    {
       

        if (activeReloadSC.freeCostSpell == true)
        {

            newFireBall = Instantiate(fireBallPrefab, firePoint.position, firePoint.rotation);
            fireBallSC = newFireBall.GetComponent<FireBall>();
            fireBallSC.damage += playerStats.fireBallBounsDamage;
            
            

            activeReloadSC.perfectStreakCount = 0;
            activeReloadSC.freeCostSpell = false;
            freeCostSpellUi.SetActive(false);
            return;
        }
        if (curentMana >= fireBallManaCost)
        {

            newFireBall= Instantiate(fireBallPrefab, firePoint.position, firePoint.rotation);
            fireBallSC = newFireBall.GetComponent<FireBall>();
            fireBallSC.damage += playerStats.fireBallBounsDamage;
            curentMana -= fireBallManaCost;

        }
    }
    public void OnFire(InputAction.CallbackContext context)
    {
        isShoting = context.ReadValue<float>();
    }
    private void Shoot()
    {


        if (curentAmmo <= 0 && isReloading == false)
        {
            Reload();
            return;
        }

        if (isShoting > 0 && curentAmmo > 0)
        {

            newBullet = Instantiate(buletPrefab, firePoint.position, firePoint.rotation);
            curentAmmo--;


            shotingTimer = 0f;
            SpriteRenderer sr = newBullet.GetComponent<SpriteRenderer>();
            TrailRenderer tr = newBullet.GetComponent<TrailRenderer>();
            bulletSc = newBullet.GetComponent<Bullet>();


            Color newColor;

            if (wasPerfectReload)
            {



                tr.emitting = true;
                if (ColorUtility.TryParseHtmlString(bulletSc.activeBulletColor, out newColor))
                {
                    sr.color = newColor;
                }
                bulletSc.bulletspeed = bulletSc.activeBulletSpeed;
                bulletSc.bulletDamage = bulletSc.activeBulletDamage + playerStats.bulletBounsDamage;
            }
            else
            {
                if (ColorUtility.TryParseHtmlString(bulletSc.normalBulletColor, out newColor))
                {
                    sr.color = newColor;
                }
                maxAmmo = orginalMaxAmmo;
                tr.emitting = false;

            }




        }





    }


    private void Reload()
    {
        activeReloadSC.StartReload();
    }
}





