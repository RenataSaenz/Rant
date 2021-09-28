using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Obstacles obstaclePref;
    private Vector3 t;

    void Update()
    {
        
        t = new Vector3 DotManager.instance.dots[0].dots[0];
        var obstacle = Instantiate(obstaclePref).SetPosition(t).SetScale(1, 1, 1);
        Debug.Log("Entre");
    }
}
