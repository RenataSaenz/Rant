using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public int damage;
    private int _counter = 1;
    void OnCollisionEnter(Collision col)
    {
        //Check to see if the Collider's name is "Chest"
        if (col.collider.tag == "Player" && _counter == 1 )
        {
            EventManager.Trigger("SubtractLife", damage);
            _counter--;
        }
    }
}
