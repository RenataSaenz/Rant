using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {

        var damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.SubtractLifeFunc(FlyweightPointer.Enemy.damage);
        }

    }
}
