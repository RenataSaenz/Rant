using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFactory<T>
{
    T Create(T bulletPrefab);
}

public class FloorFactory : IFactory<Floor>
{
    public Floor Create(Floor bulletPrefab)
    {
        var floor = Object.Instantiate(bulletPrefab);
        return floor;
    }
}

public class HandFactory : IFactory<Hand>
{
    public Hand Create(Hand bulletPrefab)
    {
        var hand = Object.Instantiate(bulletPrefab);
        return hand;
    }
}
