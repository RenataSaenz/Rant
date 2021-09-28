using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    void Start()
    {
        transform.position = DotManager.instance.dots[0].dots[0].transform.position;
    }

}
