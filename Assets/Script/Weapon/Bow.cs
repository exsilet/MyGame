using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : Firearms
{
    public override void Shoot(Transform shootPoint)
    {
        Instantiate(Arrow, shootPoint.position, shootPoint.rotation);
    }
}
