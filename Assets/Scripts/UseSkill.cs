using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSkill : MonoBehaviour
{

    [SerializeField] GameObject allyKnights;
    [SerializeField] GameObject allyMeteor;
    [SerializeField] GameObject allyBird;

    [SerializeField] DragDrop pointerLocation;

    [SerializeField] ManaBar manaBar;

    public void SummonKnight()
    {
        Instantiate(allyKnights, pointerLocation.pointerLocation, Quaternion.identity);
        manaBar.SpendMana(2);
    }

    public void SummonMeteor()
    {
        Instantiate(allyMeteor, new Vector3(pointerLocation.pointerLocation.x, pointerLocation.pointerLocation.y + 10f, pointerLocation.pointerLocation.z), Quaternion.identity);
        manaBar.SpendMana(5);
    }

    public void SummonBird()
    {
        Instantiate(allyBird, pointerLocation.pointerLocation, Quaternion.identity);
        manaBar.SpendMana(3);
    }
}