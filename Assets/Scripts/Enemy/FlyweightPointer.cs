using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FlyweightPointer 
{
    public static readonly Flyweight Enemy = new Flyweight
    {
        damage = 15
    };
}
