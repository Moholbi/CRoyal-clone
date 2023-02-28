using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Photon.Bolt;

public class BirdBehaviour : FighterUnit
{
    [SerializeField] GameObject blueDragonBreath;
    [SerializeField] GameObject redDragonBreath;

    protected override void Attacked()
    {
        if (isBlue)
        {
            BoltNetwork.Instantiate(blueDragonBreath, transform.position, Quaternion.identity);
        }
        else
        {
           BoltNetwork.Instantiate(redDragonBreath, transform.position, Quaternion.identity);
        }
    }
}