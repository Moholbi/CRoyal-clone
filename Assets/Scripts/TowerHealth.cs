using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    [SerializeField] float towerHealth;

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            towerHealth -= 1 * Time.deltaTime;
            Debug.Log("collided");

            if (towerHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}