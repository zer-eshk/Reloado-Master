using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class ActiveReload : MonoBehaviour
{
    PlayerControls Controls;
    public Shoting Shoting;
    public Bullet bullet;
    public PlayerStats PlayerStats;
    public TextMeshProUGUI perfectStreakText;
    public RectTransform bar;         // The moving bar
    public RectTransform perfectZone; // The perfect zone
    public int perfectStreakTotalCount;
    public int perfectStreakCount;
    public Image perfectZoneColor;
    private Color orgianPerfectZoneColor;
    public float barSpeed;        // Speed of bar movement
    private float startX;
    private float endX;
    public int manaGain;
    public bool freeCostSpell = false;
    public GameObject freeCostSpellUi;
    [SerializeField] bool barIsMoving = false;
    [SerializeField] bool canCheckHit = false;


    private void Awake()
    {


        if (gameObject != null)
        {
            Controls = new PlayerControls();
            Controls.Enable();
            Controls.Player.Reload.performed += (ctx) =>
            {
                if (canCheckHit == true && Shoting.isReloading == true)

                {

                    CheckHit();
                }


            };
        }

    }
    void Start()
    {


        orgianPerfectZoneColor = perfectZoneColor.color;
        // Calculate bar range (inside parent)
        startX = -((RectTransform)transform).rect.width / 2;
        endX = ((RectTransform)transform).rect.width / 2;

        ResetBar();
    }

    void Update()
    {
        if (barIsMoving)
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


        gameObject.SetActive(true);
        if (perfectStreakTotalCount == 0)
        {
            perfectStreakText.text = null;
        }
        else { perfectStreakText.text = perfectStreakTotalCount.ToString(); }

        Shoting.isReloading = true;
        canCheckHit = true;
        barIsMoving = true;

    }

    void ResetBar()
    {


        Shoting.isReloading = false;
        barIsMoving = false;
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


            perfectStreakTotalCount += 1;
            perfectStreakCount += 1;
            if (perfectStreakCount == 3)
            {
                freeCostSpell = true;


            }
            if (freeCostSpell == true)
            { freeCostSpellUi.SetActive(true); }
            canCheckHit = false;
            Shoting.maxAmmo=Shoting.activeMaxAmmo+PlayerStats.ammoBouns;
            Shoting.curentMana += manaGain;
            Shoting.curentAmmo = Shoting.maxAmmo;
            Shoting.shotingCD = Shoting.activeShotingCd;
            Shoting.wasPerfectReload = true;
            perfectZoneColor.color = orgianPerfectZoneColor;
            if (Shoting.curentMana > Shoting.maxMana)
            {
                Shoting.curentMana = Shoting.maxMana;
            }

            ResetBar();


        }
        else
        {
            Debug.Log("Failed Reload!");
            Shoting.maxAmmo = Shoting.orginalMaxAmmo;
            canCheckHit = false;
            Shoting.wasPerfectReload = false;
            perfectStreakTotalCount = 0;
            perfectStreakCount = 0;
            Shoting.shotingCD = Shoting.orginalShotingCd;
            perfectZoneColor.color = Color.red;

            // Add penalty logic here
        }
    }

    void Fail()
    {

        Debug.Log("Reload Missed (Timeout)");
        Shoting.wasPerfectReload = false;
        Shoting.maxAmmo = Shoting.orginalMaxAmmo;
        Shoting.curentAmmo = Shoting.orginalMaxAmmo;
        Shoting.isReloading = false;
        Shoting.shotingCD = Shoting.orginalShotingCd;
        canCheckHit = false;
        perfectStreakTotalCount = 0;
        perfectStreakCount = 0;
        perfectZoneColor.color = orgianPerfectZoneColor;
        ResetBar();
        // Timeout penalty logic here
    }
}

