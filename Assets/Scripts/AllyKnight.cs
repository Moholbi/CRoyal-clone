using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AllyKnight : MonoBehaviour
{
    public string tagToDetect = ("Enemy");
    [SerializeField] GameObject[] allEnemies;
    [SerializeField] GameObject closestEnemy;

    [SerializeField] NavMeshAgent myNavMeshAgent;

    void Start()
    {
        allEnemies = GameObject.FindGameObjectsWithTag(tagToDetect);
    }

    void Update()
    {
        Movement();
        closestEnemy = ClosestEnemy();
    }

    GameObject ClosestEnemy()
    {
        GameObject closestHere = gameObject;
        float leastDistance = Mathf.Infinity;

        foreach (var enemy in allEnemies)
        {
            float distanceHere = Vector3.Distance(transform.position, enemy.transform.position);

            if(distanceHere < leastDistance)
            {
                leastDistance = distanceHere;
                closestHere = enemy;
            }
        }

        return closestHere;
    }

    void Movement()
    {
        //myNavMeshAgent.SetDestination(closestEnemy.transform.position);
    }
}