using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyKnight : MonoBehaviour
{
    [SerializeField] NavMeshAgent myNavMeshAgent;

    public GameObject[] allPlayers;
    public GameObject nearestPlayer;

    [SerializeField] float unitHealth = 10f;
    [SerializeField] float distanceToFight;
    [SerializeField] float arrowDamage;

    void Update()
    {
        allPlayers = GameObject.FindGameObjectsWithTag("Player");
        FindNearestPlayer();
        CombatMode();
    }

    void FindNearestPlayer()
    {
        float nearestDistance = Mathf.Max(1000);

        for (int i = 0; i < allPlayers.Length; i++)
        {
            float distance = Vector3.Distance(this.transform.position, allPlayers[i].transform.position);

            if (distance < nearestDistance)
            {
                nearestPlayer = allPlayers[i];
                nearestDistance = distance;
            }
        }
    }

    void CombatMode()
    {
        float distance = Vector3.Distance(nearestPlayer.transform.position, transform.position);

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
        myNavMeshAgent.SetDestination(nearestPlayer.transform.position);
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.layer == LayerMask.NameToLayer("KnightDamage"))
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
        if (other.gameObject.tag == "PlayerArrow")
        {
            unitHealth -= arrowDamage;
        }

        if (unitHealth <= 0f)
        {
            Destroy(gameObject);
        }
    }
}