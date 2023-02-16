using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AllyKnight : MonoBehaviour
{
    [SerializeField] NavMeshAgent myNavMeshAgent;

    public GameObject[] allEnemies;
    public GameObject neraestEnemy;

    [SerializeField] float unitHealth = 10f;
    [SerializeField] float distanceToFight;
    [SerializeField] float arrowDamage;

    void Update()
    {
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        FindNearestEnemy();
        CombatMode();
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

    void CombatMode()
    {
        float distance = Vector3.Distance(neraestEnemy.transform.position, transform.position);

        if (distance < distanceToFight)
        {
            //Play.FightAnimation;
            myNavMeshAgent.speed = 0f;
        }

        if (distance > distanceToFight)
        {
            Movement();
            myNavMeshAgent.speed = 3.5f;
        }
    }

    void Movement()
    {
        myNavMeshAgent.SetDestination(neraestEnemy.transform.position);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy" && other.gameObject.layer == LayerMask.NameToLayer("KnightDamage"))
        {
            unitHealth -= 1f;
        }

        if (unitHealth < 0f)
        {
            Destroy(gameObject);
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
            Destroy(gameObject);
        }
    }
}