using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTower : MonoBehaviour
{
    public int sideAlive = 2;

    void Update()
    {
        if (sideAlive == 0)
        {
            gameObject.tag = ("Player");
        }
    }
}