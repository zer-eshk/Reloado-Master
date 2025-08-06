using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GameTimerSC : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float elapsedTime = 0;
    private void Update()
    {
        elapsedTime += Time.deltaTime;
        timerText.text = elapsedTime.ToString();
        
        int minutes=Mathf.FloorToInt(elapsedTime/60);
        int seconds = Mathf.FloorToInt(elapsedTime%60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
