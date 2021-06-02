using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Firearms : Weapon
{
    [SerializeField] protected Arrow Arrow;

    public abstract void Shoot(Transform shootPoint);
}
