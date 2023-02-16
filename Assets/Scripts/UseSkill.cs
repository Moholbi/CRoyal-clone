using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSkill : MonoBehaviour
{

    [SerializeField] GameObject allyKnights;
    [SerializeField] GameObject allyArcher;
    [SerializeField] GameObject allyBird;

    [SerializeField] DragDrop pointerLocation;

    [SerializeField] ManaBar manaBar;

    public void SummonKnight()
    {
        Instantiate(allyKnights, pointerLocation.pointerLocation, Quaternion.identity);
        manaBar.SpendMana(1);
    }

    public void SummonMeteor()
    {
        Instantiate(allyArcher, (pointerLocation.pointerLocation), Quaternion.identity);
        manaBar.SpendMana(3);
    }

    public void SummonBird()
    {
        Instantiate(allyBird, pointerLocation.pointerLocation, Quaternion.identity);
        manaBar.SpendMana(2);
    }
}