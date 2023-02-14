using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseSkill : MonoBehaviour
{

    [SerializeField] GameObject allyKnights;
    [SerializeField] GameObject allyMeteor;
    [SerializeField] GameObject allyGiant;

    [SerializeField] DragDrop pointerLocation;

    public void SummonKnight()
    {
        Instantiate(allyKnights, pointerLocation.pointerLocation, Quaternion.identity);
    }

    public void SummonMeteor()
    {
        Instantiate(allyMeteor, new Vector3(pointerLocation.pointerLocation.x, pointerLocation.pointerLocation.y + 10f, pointerLocation.pointerLocation.z), Quaternion.identity);
    }

    public void SummonGiant()
    {
        Instantiate(allyGiant, pointerLocation.pointerLocation, Quaternion.identity);
    }
}