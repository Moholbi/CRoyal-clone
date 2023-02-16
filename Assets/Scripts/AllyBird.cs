using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AllyBird : MonoBehaviour
{
    [SerializeField] NavMeshAgent myNavMeshAgent;

    public GameObject[] allEnemies;
    public GameObject neraestEnemy;
    private bool _arrowCreated;

    [SerializeField] GameObject arrowPrefab;
    [SerializeField] float distanceToShoot;

    [SerializeField] float unitHealth = 10f;
    [SerializeField] float arrowDamage;

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z);
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
        myNavMeshAgent.SetDestination(neraestEnemy.transform.position);
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
