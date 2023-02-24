using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Bolt;

public class PlayerHealthExample : Photon.Bolt.EntityBehaviour<IPlayerState>
{
    public int localHealth = 3;

    public override void Attached()
    {
        state.health = localHealth;

        state.AddCallback("Health", HealthCallback);
    }

    private void HealthCallback()
    {
        localHealth = state.health;

        if (localHealth <= 0)
        {
            BoltNetwork.Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            state.health -= 1;
        }
    }
}