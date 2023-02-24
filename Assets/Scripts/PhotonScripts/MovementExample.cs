using UnityEngine;
using Photon.Bolt;

public class PlayaMovement : Photon.Bolt.EntityBehaviour<IPlayerState>
{
    public override void Attached()
    {
        state.SetTransforms(state.transform, transform);
    }

    public override void SimulateOwner()
    {
        var speed = 4f;
        var movement = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            movement.x -= 1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movement.x += 1f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            movement.z += 1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            movement.z -= 1f;
        }

        if (movement != Vector3.zero)
        {
            transform.position = transform.position + (movement.normalized * speed * BoltNetwork.FrameDeltaTime);
        }
    }
}
