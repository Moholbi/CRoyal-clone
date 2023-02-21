using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MageBehaviour : FighterUnit
{
    string[] spellTypes = { "BlueSpell", "RedSpell" };
    private string _selectedSpell;

    protected override void Attacked()
    {
        if (isBlue)
        {
            _selectedSpell = "BlueSpell";
        }
        else
        {
            _selectedSpell = "RedSpell";
        }

        objectPooler.SpawnFromPool(_selectedSpell, transform.position, Quaternion.identity);
    }
}