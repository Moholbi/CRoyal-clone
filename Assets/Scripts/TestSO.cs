using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "Character")]
public class TestSO : ScriptableObject
{
    [SerializeField] public int Damage;
    [SerializeField] public int Heal;
    [SerializeField] public float Speed;
    [SerializeField] public float AttackSpeed;
    [SerializeField] public float MaxHealth;
    [SerializeField] public float AttackDistance;

    [SerializeField] public bool isAerial;
    [SerializeField] public bool isMelee;
    [SerializeField] public bool isSupport;
}