using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dager : Weapon
{
    public override void Shoot()
    {
        base.Shoot();
        Debug.Log("Dager Shoot");
    }
}
