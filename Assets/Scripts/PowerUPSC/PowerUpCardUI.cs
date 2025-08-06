using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class PowerUpCardUI : MonoBehaviour
{
    public Image icon;
    public TMP_Text nameText;
    public TMP_Text descriptionText;

    private PowerUpSo currentPowerUp;
    private PowerUpSystem system;

    public void Setup(PowerUpSo powerUp, PowerUpSystem powerUpSystem)
    {
        currentPowerUp = powerUp;
        system = powerUpSystem;

        icon.sprite = powerUp.icon;
        nameText.text = powerUp.powerUpName;
        descriptionText.text = powerUp.description;
    }

    public void OnClick()
    {
        system.ApplyPowerUp(currentPowerUp);
    }
}