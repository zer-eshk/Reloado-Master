using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New PowerUp", menuName = "PowerUp")]
public class PowerUpSo : ScriptableObject
{

    public string powerUpName;         // e.g. "Rapid Fire"
    public string description;         // e.g. "Increases fire rate by 20%"
    public Sprite icon;                // What shows on the card
    public powerUpType type;           // Enum to determine what this power-up does
    public float value;


    public enum powerUpType
    {
        IncreaseAmmo,
        IncreaseFireDamage,
        IncreaseFireRate,
        IncreaseMoveSpeed,
        IncreaseFireBallDamage
    }
       
}
 