using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anthill : MonoBehaviour, ICollectable
{
    public void Collect()
    {
        EventManager.Trigger("GameWon");
    }

    /*void OnCollisionEnter(Collision col)
    {
        var damageable = col.collider.GetComponent<IDamageable>();
        if (damageable != null)
        {
            EventManager.Trigger("GameWon");
        }
    }*/
}
