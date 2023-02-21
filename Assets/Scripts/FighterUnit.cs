using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Sirenix.OdinInspector;

public class FighterUnit : Damagable
{
    protected List<Damagable> TargetList;
    protected Damagable nearestEnemy;
    protected ObjectPooler objectPooler;
    public bool isBlue;
    protected bool isAttacking;

    [SerializeField] public TestSO statList;
    [SerializeField] protected NavMeshAgent myNavMeshAgent;
    [SerializeField] protected Animator fighterAnimator;
    [SerializeField] private HealthBar _healthBar;

    private float _maxHealth;
    public float unitHealth;

    void Start()
    {
        TypeDecider();

        _maxHealth = statList.MaxHealth;
        unitHealth = statList.MaxHealth;

        _healthBar.UpdateHealthBar(_maxHealth, unitHealth);
        objectPooler = ObjectPooler.Instance;
    }

    void TypeDecider()
    {
        if (statList.isAerial)
        {
            gameObject.layer = LayerMask.NameToLayer("Aerial");
        }

        if (statList.isMelee)
        {
            gameObject.layer = LayerMask.NameToLayer("Melee");
        }

        if (statList.isSupport)
        {
            gameObject.layer = LayerMask.NameToLayer("Support");
        }
    }

    void Update()
    {
        if (!isAttacking) FindNearest();
        else Attack();
    }

    protected virtual void FindNearest()
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
            if (TargetList[i].gameObject.layer == LayerMask.NameToLayer("Aerial") && statList.isMelee) continue;
            float distanceToEnemy = (currentPosition - TargetList[i].transform.position).sqrMagnitude;
            if (distanceToEnemy < nearestDistance)
            {
                nearestEnemy = TargetList[i];
                nearestDistance = distanceToEnemy;
            }
        }

        if (nearestEnemy != null && TargetList.Contains(nearestEnemy))
        {
            myNavMeshAgent.speed = statList.Speed;
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

    void Attack()
    {
        fighterAnimator.SetBool("isAttacking", true);
        fighterAnimator.speed = statList.AttackSpeed;
        if (!TargetList.Contains(nearestEnemy))
        {
            isAttacking = false;
            fighterAnimator.SetBool("isAttacking", false);
        }
    }

    protected virtual void Attacked()
    {
        nearestEnemy.GotHit(statList.Damage);
    }

    protected virtual void Healed()
    {
        nearestEnemy.GotHealed(statList.Damage);
    }

    public override void GotHit(int damage)
    {
        unitHealth -= damage;
        Debug.Log(damage);
        _healthBar.UpdateHealthBar(_maxHealth, unitHealth);
        if (unitHealth <= 0)
        {
            Death();
        }
    }

    public override void GotHealed(int healAmount)
    {
        if (unitHealth < _maxHealth)
        {
            unitHealth += healAmount;
            _healthBar.UpdateHealthBar(_maxHealth, unitHealth);
        }
    }

    void Death()
    {
        if (isBlue)
        {
            TargetList = AliveUnitHolder.BlueUnitList;
        }

        if (!isBlue)
        {
            TargetList = AliveUnitHolder.RedUnitList;
        }

        TargetList.Remove(this);
        this.gameObject.SetActive(false);
        unitHealth = 300f;
    }
}