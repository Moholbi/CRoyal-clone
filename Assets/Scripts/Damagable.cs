using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagable : MonoBehaviour
{
    public virtual void GotHit(int damage)
    {
        
    }

    public virtual void GotHealed(int healAmount)
    {

    }
}