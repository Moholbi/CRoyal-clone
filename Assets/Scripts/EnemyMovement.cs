using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    GameObject leftTower;
    GameObject rightTower;
    GameObject midTower;

    [SerializeField] NavMeshAgent myNavMeshAgent;

    private Vector3 targetTower;

    public static List<Transform> TargetList;

    void Start()
    {
        leftTower = GameObject.Find("LeftTower");
        rightTower = GameObject.Find("RightTower");
        midTower = GameObject.Find("MainTower");
    }

    void Update()
    {
        Movement();
        TargetPicker();
    }

    //Düşmanın spawn olduğu konuma göre hangi taraftaki tower'ı hedef alacağını belirler
    void TargetPicker()
    {
        if (gameObject.transform.position.x < 0)
        {
            targetTower = leftTower.transform.position;
        }

        if (gameObject.transform.position.x > 0)
        {
            targetTower = rightTower.transform.position;
        }

        if (targetTower == null)
        {
            targetTower = midTower.transform.position;
        }
    }

    void Movement()
    {
        myNavMeshAgent.SetDestination(targetTower);
    }
}