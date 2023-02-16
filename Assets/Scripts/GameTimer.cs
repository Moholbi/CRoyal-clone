using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerUI;
    [SerializeField] public float gameTimer = 60f;

    void Update()
    {
        SetTimerText();
    }

    public void SetTimerText()
    {
        gameTimer -= Time.deltaTime;
        timerUI.text = "Timer:" + gameTimer.ToString("0");
        if (gameTimer <= 0)
        {
            timerUI.text = ("Time Up");
        }
    }
}