using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public int damage;

    void OnCollisionEnter(Collision col)
    {
        var damageable = col.collider.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.SubtractLifeFunc(damage);
        }
        
    }
}
