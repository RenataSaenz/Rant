using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooka : Weapon
{
    public override void Shoot()
    {
        base.Shoot();
        Debug.Log("Pistol Shoot");
    }
    
}

