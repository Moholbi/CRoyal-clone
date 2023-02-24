using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] CastleBehaviour blueCastleHealth;
    [SerializeField] CastleBehaviour redCastleHealth;
    [SerializeField] GameTimer gameTimer;

    void Update()
    {
        if (blueCastleHealth.unitHealth <= 0 && StartMenu.cameraChoice == 2)
        {
            SceneManager.LoadScene(2);
        }

        if (redCastleHealth.unitHealth <= 0 && StartMenu.cameraChoice == 2)
        {
            SceneManager.LoadScene(3);
        }

        if (blueCastleHealth.unitHealth <= 0 && StartMenu.cameraChoice == 3)
        {
            SceneManager.LoadScene(3);
        }

        if (redCastleHealth.unitHealth <= 0 && StartMenu.cameraChoice == 3)
        {
            SceneManager.LoadScene(2);
        }

        if (gameTimer.gameTimer <= 0)
        {
            SceneManager.LoadScene(3);
        }
    }
}