using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleBehaviour : Damagable
{
    public int blueIsTargetable;
    public int redIsTargetable;
    [SerializeField] bool isBlue;
    [SerializeField] private float _maxHealth;
    [SerializeField] public float unitHealth;
    [SerializeField] private HealthBar _healthBar;

    public void AddCastle()
    {
        if (isBlue && blueIsTargetable >= 2 && gameObject.CompareTag("Blue"))
        {
            AliveUnitHolder.BlueUnitList.Add(this);
        }

        if (!isBlue && redIsTargetable >= 2 && gameObject.CompareTag("Red"))
        {
            AliveUnitHolder.RedUnitList.Add(this);
        }
    }

    public override void GotHit(int damage)
    {
        unitHealth -= damage;
        _healthBar.UpdateHealthBar(_maxHealth, unitHealth);
    }
}