using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerXpLogic : MonoBehaviour
{
    public float playerCurentXp;
    public int playerLvl = 1;
    public float xpNeedForLvlUp;
    public float xpGrowthRate = 1.5f;
    private void Update()
    {
        if (playerCurentXp >= xpNeedForLvlUp)
        {
            LvlUP();
        }
    }
    void LvlUP()
    {
        FindObjectOfType<PowerUpSystem>().ShowLevelUpChoices();
        playerCurentXp -=xpNeedForLvlUp;
        playerLvl++;
        xpNeedForLvlUp*=xpGrowthRate;
        Debug.Log("lvlup");
    }
    public void AddXp(float xpAmount)
    {
        playerCurentXp += xpAmount;
    }
}
