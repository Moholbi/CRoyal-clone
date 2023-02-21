using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BirdBehaviour : FighterUnit
{
    string[] spellTypes = { "BlueDragonBreath", "RedDragonBreath" };
    private string _selectedSpell;

    protected override void Attacked()
    {
        if (isBlue)
        {
            _selectedSpell = "BlueDragonBreath";
        }
        else
        {
            _selectedSpell = "RedDragonBreath";
        }

        objectPooler.SpawnFromPool(_selectedSpell, transform.position, Quaternion.identity);
    }
}