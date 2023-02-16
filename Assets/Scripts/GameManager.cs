using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] TowerHealth unitHealth;
    [SerializeField] GameTimer gameTimer;

    void Update()
    {
        if(unitHealth.unitHealth <= 0)
        {
            SceneManager.LoadScene(2);
        }

        if(gameTimer.gameTimer <= 0)
        {
            SceneManager.LoadScene(3);
        }
    }
}