using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XpCrystalSC : MonoBehaviour
{
    public XpcrystalType crystalType;
    public float normalXp = 1;
    public float eliteXp = 10;
    public float rangeXp = 3;
    public float followSpeed;
    public float followRange;
    private Transform player;
    

    private void Start()
    {

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
            player = playerObject.transform;
    }

    private void Update()
    {
        if (player != null)
        {
            float Distance = Vector2.Distance(transform.position, player.position);

            if (Distance < followRange)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, followSpeed * Time.deltaTime);
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            PlayerXpLogic playerXp = other.GetComponent<PlayerXpLogic>();
            if (playerXp != null)
            {
                float xpToGive = getXpAmount();
                playerXp.AddXp(xpToGive);
            }

            Destroy(gameObject);
        }
    }

    private float getXpAmount()
    {

        
        switch (crystalType)
        {
            case XpcrystalType.Elite:



                return eliteXp;
            case XpcrystalType.Range:


                return rangeXp;
            case XpcrystalType.Normal:
            default:
                return normalXp;




        }
    }

    public enum XpcrystalType
    {
        Normal,
        Range,
        Elite
    }
}
