using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBehaviour : MonoBehaviour
{
    List<Damagable> TargetList;
    Damagable nearestEnemy;
    ObjectPooler objectPooler;
    float projectileSpeed = 10f;
    int healAmount;
    [SerializeField] TestSO statList;

    void Start()
    {
        healAmount = statList.Heal;
    }

    void Update()
    {
        TargetChooser();
    }

    void TargetChooser()
    {
        if (this.gameObject.tag == "Blue")
        {
            FindNearestBlue();
        }

        if (this.gameObject.tag == "Red")
        {
            FindNearestRed();
        }
    }

    void FindNearestRed()
    {
        TargetList = AliveUnitHolder.RedUnitList;
        nearestEnemy = null;
        float nearestDistance = float.MaxValue;
        Vector3 currentPosition = transform.position;

        for (int i = 0; i < TargetList.Count; i++)
        {
            if (TargetList[i].gameObject.layer == LayerMask.NameToLayer("Support") || TargetList[i].gameObject.layer == LayerMask.NameToLayer("Tower")) continue;
            float distanceToEnemy = (currentPosition - TargetList[i].transform.position).sqrMagnitude;
            if (distanceToEnemy < nearestDistance)
            {
                nearestEnemy = TargetList[i];
                nearestDistance = distanceToEnemy;
            }
        }

        Movement();
    }

    void FindNearestBlue()
    {
        TargetList = AliveUnitHolder.BlueUnitList;
        nearestEnemy = null;
        float nearestDistance = float.MaxValue;
        Vector3 currentPosition = transform.position;

        for (int i = 0; i < TargetList.Count; i++)
        {
            if (TargetList[i].gameObject.layer == LayerMask.NameToLayer("Support") || TargetList[i].gameObject.layer == LayerMask.NameToLayer("Tower")) continue;
            float distanceToEnemy = (currentPosition - TargetList[i].transform.position).sqrMagnitude;
            if (distanceToEnemy < nearestDistance)
            {
                nearestEnemy = TargetList[i];
                nearestDistance = distanceToEnemy;
            }
        }

        Movement();
    }

    void Movement()
    {
        transform.position = Vector3.Lerp(transform.position, nearestEnemy.transform.position, projectileSpeed * Time.deltaTime);
        float distanceFromEnemy = Vector3.Distance(nearestEnemy.transform.position, transform.position);
        transform.position = new Vector3(transform.position.x, 1f, transform.position.z);

        if (distanceFromEnemy < 1)
        {
            gameObject.SetActive(false);
            Healed();
        }
    }

    protected virtual void Healed()
    {
        nearestEnemy.GotHealed(healAmount);
    }
}