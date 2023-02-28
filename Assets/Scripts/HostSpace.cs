using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

[BoltGlobalBehaviour(BoltNetworkModes.Server)]
public class HostSpace : GlobalEventListener
{
    public override void OnEvent(SpawnUnitEvent evnt)
    {
        BoltNetwork.Instantiate(evnt.PrefabID, evnt.PrefabPosition, evnt.PrefabRotation);
    }

    public override void OnEvent(DestroyUnitEvent evnt)
    {
        BoltNetwork.Destroy(BoltNetwork.FindEntity(evnt.DestroyID).gameObject);
    }
}