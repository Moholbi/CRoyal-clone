using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{
    [SerializeField] public float unitHealth;
    [SerializeField] float arrowDamage;
    [SerializeField] MainTower mainTower;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            unitHealth -= 1 * Time.deltaTime;
            Debug.Log("collided");

            if (unitHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyArrow")
        {
            unitHealth -= arrowDamage;
        }

        if (unitHealth <= 0f)
        {
            mainTower.sideAlive--;
            Destroy(gameObject, 0.1f);
        }
    }
}