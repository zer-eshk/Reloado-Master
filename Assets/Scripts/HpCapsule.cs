using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpCapsule : MonoBehaviour
{
    public int amount = 20;
    public float lifeTime = 10;
    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PLayerHP pLayerHP = other.GetComponent<PLayerHP>();
            if (pLayerHP != null)
            {
                
                pLayerHP.curentHp =pLayerHP.curentHp+ amount;
                if (pLayerHP.curentHp >= pLayerHP.maxHP)
                {
                    pLayerHP.curentHp = pLayerHP.maxHP;
                }
                Destroy(gameObject);
            }

        }
    }
}
