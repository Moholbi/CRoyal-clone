using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDecider : MonoBehaviour
{
    [SerializeField] GameObject camera1;
    [SerializeField] GameObject camera2;

    [SerializeField] GameObject blueCanvas;
    [SerializeField] GameObject redCanvas;

    void Start()
    {
        if (StartMenu.cameraChoice == 1)
        {
            camera1.SetActive(false);
            camera2.SetActive(false);
            blueCanvas.SetActive(false);
            redCanvas.SetActive(false);

        }
        if (StartMenu.cameraChoice == 2)
        {
            camera1.SetActive(true);
            camera2.SetActive(false);
            blueCanvas.SetActive(true);
            redCanvas.SetActive(false);
        }
        if (StartMenu.cameraChoice == 3)
        {
            camera1.SetActive(false);
            camera2.SetActive(true);
            blueCanvas.SetActive(false);
            redCanvas.SetActive(true);
        }

        Debug.Log("camera " + StartMenu.cameraChoice);
    }
}