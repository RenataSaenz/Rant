﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : Weapon
{
    public override void Shoot()
    {
        base.Shoot();
        Debug.Log("ShotGun Shoot");
    }
}
