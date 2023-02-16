using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyArrow : MonoBehaviour
{
    public GameObject[] allEnemies;
    public GameObject neraestEnemy;
    float nearestDistance = Mathf.Max(1000);

    [SerializeField] float arrowSpeed;

    void Update()
    {
        allEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        FindNearestEnemy();
        Movement();
    }

    void FindNearestEnemy()
    {
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
        if (neraestEnemy == null)
        {
            Debug.Log("null");
            Destroy(this.gameObject);
        }
        
        transform.position = Vector3.Lerp(transform.position, neraestEnemy.transform.position, arrowSpeed * Time.deltaTime);
        transform.LookAt(neraestEnemy.transform.position, Vector3.down);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }


}
