using UnityEngine;
using System.Collections.Generic;

public class PowerUpSystem : MonoBehaviour
{
    public GameObject levelUpPanel;
    public GameObject cardPrefab;
    public Transform cardHolder;
    public List<PowerUpSo> allPowerUps;
    public PlayerStats playerStats;

    void Start()
    {
        levelUpPanel.SetActive(false);
    }

    public void ShowLevelUpChoices()
    {
        Time.timeScale = 0f;
        Debug.Log("Spawning PowerUp Card!");
        levelUpPanel.SetActive(true);

        foreach (Transform child in cardHolder)
            Destroy(child.gameObject);

        var choices = GetRandomPowerUps(3);
        foreach (var powerUp in choices)
        {
            GameObject card = Instantiate(cardPrefab, cardHolder);
            card.GetComponent<PowerUpCardUI>().Setup(powerUp, this);
        }
    }

    public void ApplyPowerUp(PowerUpSo selected)
    {
        Debug.Log("selectet");
        Debug.Log("Selected: " + selected.powerUpName);

        switch(selected.type)

        {
            case PowerUpSo.powerUpType.IncreaseFireDamage:
                
                playerStats.bulletBounsDamage+=Mathf.RoundToInt(selected.value); break;
            case PowerUpSo.powerUpType.IncreaseFireBallDamage:
                playerStats.fireBallBounsDamage +=Mathf.RoundToInt( selected.value);

                break;
            case PowerUpSo.powerUpType.IncreaseAmmo:
                playerStats.ammoBouns += Mathf.RoundToInt(selected.value);
                break;
        }    
        // TODO: Add real effect here
        levelUpPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    private List<PowerUpSo> GetRandomPowerUps(int count)
    {
        List<PowerUpSo> result = new List<PowerUpSo>();
        List<PowerUpSo> pool = new List<PowerUpSo>(allPowerUps);

        for (int i = 0; i < count && pool.Count > 0; i++)
        {
            int index = Random.Range(0, pool.Count);
            result.Add(pool[index]);
            pool.RemoveAt(index);
        }

        return result;
    }
}
