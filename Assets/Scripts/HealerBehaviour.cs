using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HealerBehaviour : FighterUnit
{
    string[] spellTypes = { "BlueHeal", "RedHeal" };
    private string _selectedSpell;

    protected override void Attacked()
    {
        if (isBlue)
        {
            _selectedSpell = "BlueHeal";
        }
        else
        {
            _selectedSpell = "RedHeal";
        }

        objectPooler.SpawnFromPool(_selectedSpell, transform.position, Quaternion.identity);
    }

    protected override void FindNearest()
    {
        if (isBlue)
        {
            TargetList = AliveUnitHolder.BlueUnitList;
        }

        if (!isBlue)
        {
            TargetList = AliveUnitHolder.RedUnitList;
        }

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

        if (nearestEnemy != null && TargetList.Contains(nearestEnemy))
        {
            myNavMeshAgent.SetDestination(nearestEnemy.transform.position);

            if (nearestDistance < statList.AttackDistance)
            {
                isAttacking = true;
                myNavMeshAgent.ResetPath();
            }
        }
        else
        {
            myNavMeshAgent.ResetPath();
            isAttacking = false;
        }
    }
}