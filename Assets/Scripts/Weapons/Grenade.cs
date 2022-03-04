using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Weapon
{
    public override void Shoot()
    {
        base.Shoot();
        Debug.Log("Grenade Shoot");
    }
}
