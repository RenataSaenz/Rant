﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : Prototype
{
    public int damage;

    public Obstacles SetPosition(Vector3 position)
    {
        transform.position = new Vector3();
        return this;
    }

    public Obstacles SetScale(float x = 1, float y = 1, float z = 1)
    {
        transform.localScale = new Vector3(x, y, z);
        return this;
    }

    void OnCollisionEnter(Collision col)
    {
        var damageable = col.collider.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.SubtractLifeFunc(damage);
        }
        
    }
}
