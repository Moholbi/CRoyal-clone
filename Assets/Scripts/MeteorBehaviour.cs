using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorBehaviour : MonoBehaviour
{
    [SerializeField] float fallSpeed;

    void Update()
    {
        transform.Translate(0, fallSpeed * Time.deltaTime, 0);
    }

    void OnCollisionEnter(Collision other)
    {
        Destroy(this.gameObject);
    }
}