using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anthill : MonoBehaviour
{
    private int _counter = 1;
    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Player" && _counter == 1)
        {
            _counter--;
            EventManager.Trigger("GameWon");
        }
    }
}
