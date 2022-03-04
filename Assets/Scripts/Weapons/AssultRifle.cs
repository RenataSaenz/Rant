using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssultRifle :Weapon
{
    public override void Shoot()
    {
        base.Shoot();
        Debug.Log("Rifle Shoot");
    }
}
