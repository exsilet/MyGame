using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EdgedWeapons : Weapon
{
    [SerializeField] protected Blade Blade;
    public abstract void Hit(Transform atackPoint);
}
