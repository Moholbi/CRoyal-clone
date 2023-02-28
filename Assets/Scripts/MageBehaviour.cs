using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Bolt;

public class MageBehaviour : FighterUnit
{
    //[SerializeField] GameObject blueSpell;
    //[SerializeField] GameObject redSpell;

    [SerializeField] BoltEntity blueSpellPrefab;
    [SerializeField] BoltEntity redSpellPrefab;

    protected override void Attacked()
    {
        if (isBlue)
        {
            //Instantiate(blueSpell, transform.position, Quaternion.identity);
            var evnt = SpawnUnitEvent.Create();
            evnt.PrefabID = blueSpellPrefab.PrefabId;
            evnt.PrefabPosition = transform.position;
            evnt.PrefabRotation = Quaternion.identity;
            evnt.Send();
        }

        else
        {
            //Instantiate(redSpell, transform.position, Quaternion.identity);
            var evnt = SpawnUnitEvent.Create();
            evnt.PrefabID = redSpellPrefab.PrefabId;
            evnt.PrefabPosition = transform.position;
            evnt.PrefabRotation = Quaternion.identity;
            evnt.Send();
        }
    }
}