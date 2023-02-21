using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image _healthBarSprite;

    private Transform _cam;

    void Start()
    {
        _cam = Camera.main.transform;
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