using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerUI;
    [SerializeField] float gameTimer = 60f;
    [SerializeField] GameManager gameManager;

    bool timeUp = true;

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
            timeUp = true;
            timerUI.text = ("Time Up");
            Time.timeScale = 0;
        }
    }
}