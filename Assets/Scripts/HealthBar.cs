using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBarSprite;

    [SerializeField] GameObject blueCamera;
    [SerializeField] GameObject redCamera;

    private Transform _cam;

    void Start()
    {
        if (StartMenu.cameraChoice == 2)
        {
            _cam = blueCamera.transform;
        }

        if (StartMenu.cameraChoice == 3)
        {
            _cam = redCamera.transform;
        }
    }

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        _healthBarSprite.fillAmount = currentHealth / maxHealth;
    }

    void LateUpdate()
    {
        transform.LookAt(transform.position + _cam.forward);
    }
}