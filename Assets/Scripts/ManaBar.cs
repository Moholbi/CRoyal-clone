using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public int maxMana = 10;
    public int currentMana;
    [SerializeField] Slider manaSlider;
    public float currentManaFloat;

    void Start()
    {
        currentManaFloat = maxMana;
        manaSlider.maxValue = maxMana;
    }

    void Update()
    {
        ManaReplenish();
    }

    void ManaReplenish()
    {
        if (currentMana < maxMana)
        {
            currentManaFloat += Time.deltaTime;
            currentMana = (int)currentManaFloat;
            manaSlider.value = currentManaFloat;
        }
    }

    public void SpendMana(int manaCost)
    {
        currentMana -= manaCost;
        currentManaFloat = currentMana;
    }
}