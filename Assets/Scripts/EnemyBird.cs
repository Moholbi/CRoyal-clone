using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBird : MonoBehaviour
{
    [SerializeField] NavMeshAgent myNavMeshAgent;

    public GameObject[] allPlayers;
    public GameObject nearestPlayer;
    private bool _arrowCreated;

    [SerializeField] GameObject arrowPrefab;
    [SerializeField] float distanceToShoot;

    [SerializeField] float unitHealth = 10f;
    [SerializeField] float arrowDamage;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z);
        allPlayers = GameObject.FindGameObjectsWithTag("Player");
        FindNearestEnemy();
        CombatMode();
    }

    void FindNearestEnemy()
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

        if (distance < distanceToShoot)
        {
            StartCoroutine(Shoot());
            myNavMeshAgent.speed = 0f;
        }

        if (distance > distanceToShoot)
        {
            Movement();
            myNavMeshAgent.speed = 3.5f;
        }
    }

    IEnumerator Shoot()
    {
        while (!_arrowCreated)
        {
            Instantiate(arrowPrefab, transform.position, Quaternion.identity, this.transform);
            _arrowCreated = true;
            yield return new WaitForSeconds(2f);
            _arrowCreated = false;
        }
    }

    void Movement()
    {
        myNavMeshAgent.SetDestination(nearestPlayer.transform.position);
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
