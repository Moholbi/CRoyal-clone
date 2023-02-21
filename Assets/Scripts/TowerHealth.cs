using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : Damagable
{
    List<Damagable> FactionList;

    [SerializeField] private float _maxHealth;
    [SerializeField] public float unitHealth;
    [SerializeField] private HealthBar _healthBar;
    [SerializeField] bool isBlue;
    [SerializeField] CastleBehaviour castleBehaviour;

    void Start()
    {
        _healthBar.UpdateHealthBar(_maxHealth, unitHealth);
        Faction();
    }

    void Faction()
    {
        if (gameObject.CompareTag("Blue"))
        {
            AliveUnitHolder.BlueUnitList.Add(this);
        }

        if (gameObject.CompareTag("Red"))
        {
            AliveUnitHolder.RedUnitList.Add(this);
        }
    }

    public override void GotHit(int damage)
    {
        unitHealth -= damage;
        _healthBar.UpdateHealthBar(_maxHealth, unitHealth);
        if (unitHealth <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        if (isBlue)
        {
            FactionList = AliveUnitHolder.BlueUnitList;
            castleBehaviour.blueIsTargetable += 1;
        }

        if (!isBlue)
        {
            FactionList = AliveUnitHolder.RedUnitList;
            castleBehaviour.redIsTargetable += 1;
        }

        FactionList.Remove(this);
        this.gameObject.SetActive(false);
        castleBehaviour.AddCastle();
    }
}