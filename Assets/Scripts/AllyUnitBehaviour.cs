using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AllyUnitBehaviour : MonoBehaviour
{
    [SerializeField] NavMeshAgent myNavMeshAgent;

    public GameObject[] allEnemies;
    public GameObject neraestEnemy;

    [SerializeField] float unitHealth = 10f;

    void Update()
    {
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        FindNearestEnemy();
        Movement();
    }

    void FindNearestEnemy()
    {
        float nearestDistance = Mathf.Max(1000);

        for (int i = 0; i < allEnemies.Length; i++)
        {
            float distance = Vector3.Distance(this.transform.position, allEnemies[i].transform.position);

            if (distance < nearestDistance)
            {
                neraestEnemy = allEnemies[i];
                nearestDistance = distance;
            }
        }
    }

    void Movement()
    {
        myNavMeshAgent.SetDestination(neraestEnemy.transform.position);
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            unitHealth -= 1f;
        }

        if (unitHealth < 0f)
        {
            Destroy(gameObject);
        }
    }
}