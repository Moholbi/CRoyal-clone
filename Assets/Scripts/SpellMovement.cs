using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Sirenix.OdinInspector;

public class SpellMovement : Damagable
{
    List<Damagable> TargetList;
    Damagable nearestEnemy;
    ObjectPooler objectPooler;
    [SerializeField] float spellSpeed = 10f;

    public bool isBlue;

    void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }


    void FindNearest()
    {
        if (!isBlue)
        {
            TargetList = AliveUnitHolder.BlueUnitList;
        }

        if (isBlue)
        {
            TargetList = AliveUnitHolder.RedUnitList;
        }

        nearestEnemy = null;
        float nearestDistance = float.MaxValue;
        Vector3 currentPosition = transform.position;

        for (int i = 0; i < TargetList.Count; i++)
        {
            float distanceToEnemy = (currentPosition - TargetList[i].transform.position).sqrMagnitude;
            if (distanceToEnemy < nearestDistance)
            {
                nearestEnemy = TargetList[i];
                nearestDistance = distanceToEnemy;
            }
        }
    }

    void Movement()
    {
        transform.position = Vector3.Lerp(transform.position, nearestEnemy.transform.position, spellSpeed * Time.deltaTime);
        transform.LookAt(nearestEnemy.transform.position, Vector3.down);
        float distanceFromEnemy = Vector3.Distance(nearestEnemy.transform.position, transform.position);

        if (distanceFromEnemy < 0.5)
        {
            gameObject.SetActive(false);
            Attacked();
        }
    }

    protected virtual void Attacked()
    {
        nearestEnemy.GotHit(100);
    }
}