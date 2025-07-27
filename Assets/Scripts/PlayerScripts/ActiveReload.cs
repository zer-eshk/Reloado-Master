using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class ActiveReload : MonoBehaviour
{
    PlayerControls controls;
    public Shoting Shoting;
    public Bullet bullet;
    public RectTransform bar;         // The moving bar
    public RectTransform perfectZone; // The perfect zone
    public Image perfectZoneColor;
    private Color orgianPerfectZoneColor;
    public float barSpeed;        // Speed of bar movement
    private float startX;
    private float endX;
    public int manaGain;
    [SerializeField] bool isMoving = false;
    [SerializeField] bool canPeresR;

    private void Awake()
    {


        if (gameObject != null)
        {
            controls = new PlayerControls();
            controls.Enable();
            controls.Player.Reload.performed += (ctx) =>
            {
                if(canPeresR)
                {
                    CheckHit();
                }
                
                
            };
        }

    }
    void Start()
    {
        //bullet.orginalSpeed=bullet.bulletspeed;
        
        orgianPerfectZoneColor =perfectZoneColor.color;
        // Calculate bar range (inside parent)
        startX = -((RectTransform)transform).rect.width / 2;
        endX = ((RectTransform)transform).rect.width / 2;

        ResetBar();
    }

    void Update()
    {
        if (isMoving)
        {
            bar.anchoredPosition += Vector2.right * barSpeed * Time.deltaTime;

            if (bar.anchoredPosition.x > endX)
            {
                Fail(); // Missed
                ResetBar();
            }


        }
    }

    public void StartReload()
    {
        canPeresR = true;
        Shoting.isReloading = true;
        gameObject.SetActive(true);
        isMoving = true;
    }

    void ResetBar()
    {
        Shoting.isReloading=false;
        isMoving = false;
        bar.anchoredPosition = new Vector2(startX, 0);
        
        gameObject.SetActive(false);

    }

    void CheckHit()
    {
        float barX = bar.anchoredPosition.x;
        float perfectMin = perfectZone.anchoredPosition.x - perfectZone.rect.width / 2;
        float perfectMax = perfectZone.anchoredPosition.x + perfectZone.rect.width / 2;

        if (barX >= perfectMin && barX <= perfectMax)
        {
            Debug.Log("Perfect Reload!");
            
             
             bullet.bulletColor.color=Color.black;
            Shoting.curentMana += manaGain;
            Shoting.curentAmmo = Shoting.maxAmmo;
            Shoting.shotingCD=Shoting.activeShotingCd;
            Shoting.wasPerfectReload=true;
            if (Shoting.curentMana > Shoting.maxMana)
            {
                Shoting.curentMana = Shoting.maxMana;
            }
            canPeresR = false;
            ResetBar();


        }
        else
        {
            Debug.Log("Failed Reload!");
            
            Shoting.wasPerfectReload = false;
            Shoting.shotingCD=Shoting.orginalShotingCd;
            canPeresR = false;
            perfectZoneColor.color = Color.red;
            // Add penalty logic here
        }
    }

    void Fail()
    {
        Debug.Log("Reload Missed (Timeout)");
        Shoting.wasPerfectReload = false;
        Shoting.curentAmmo = Shoting.maxAmmo;
        Shoting.isReloading = false;
        Shoting.shotingCD = Shoting.orginalShotingCd;
        canPeresR = false;
        perfectZoneColor.color = orgianPerfectZoneColor;
        // Timeout penalty logic here
    }
}

