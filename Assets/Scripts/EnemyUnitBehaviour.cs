using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyUnitBehaviour : MonoBehaviour
{
    [SerializeField] NavMeshAgent myNavMeshAgent;

    public GameObject[] allPlayers;
    public GameObject neraestEnemy;

    [SerializeField] float unitHealth = 10f;

    void Update()
    {
        allPlayers = GameObject.FindGameObjectsWithTag("Player");
        FindNearestPlayer();
        Movement();
    }

    void FindNearestPlayer()
    {
        float nearestDistance = Mathf.Max(1000);

        for (int i = 0; i < allPlayers.Length; i++)
        {
            float distance = Vector3.Distance(this.transform.position, allPlayers[i].transform.position);

            if (distance < nearestDistance)
            {
                neraestEnemy = allPlayers[i];
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
        if (other.gameObject.tag == "Player")
        {
            unitHealth -= 1f;
        }

        if (unitHealth < 0f)
        {
            Destroy(gameObject);
        }
    }
}