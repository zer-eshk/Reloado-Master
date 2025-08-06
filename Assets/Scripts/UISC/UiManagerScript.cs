using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManagerScript : MonoBehaviour
{
    public TextMeshProUGUI currentAmmo;
    public TextMeshProUGUI maxAmmo;
    public TextMeshProUGUI playerHp;
    public TextMeshProUGUI playerMana;
    public Shoting Shoting;
    public PLayerHP PLayerHP;
    private void Start()
    {
        if (PLayerHP == null)
        {
            Debug.Log("missing script");
        }
        if (Shoting == null)
        {
            Debug.Log("missing script");
        }

    }
    private void Update()
    {

        if (Shoting != null)
        {
            currentAmmo.text = Shoting.curentAmmo.ToString();
            maxAmmo.text = Shoting.maxAmmo.ToString();
            playerMana.text = Shoting.curentMana.ToString();
        }
        if (PLayerHP != null)
        {
            playerHp.text = PLayerHP.curentHp.ToString();

        }



    }
}
