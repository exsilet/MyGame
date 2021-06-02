using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : EdgedWeapons
{
    public override void Hit(Transform atackPoint)
    {
        Instantiate(Blade, atackPoint.position, atackPoint.rotation);
    }
}
