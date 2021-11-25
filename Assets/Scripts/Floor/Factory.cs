using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFactory<T>
{
    T Create(T parameter);
}

public class FloorFactory : IFactory<Floor>
{
    public Floor Create(Floor floorPrefab)
    {
        var floor = Object.Instantiate(floorPrefab);
        return floor;
    }
}

public class ProjectileFactory : IFactory<Projectile>
{
    public Projectile Create(Projectile projectilePrefab)
    {
        var projectile = Object.Instantiate(projectilePrefab);
        return projectile;
    }
}

public class HandFactory : IFactory<Hand>
{
    public Hand Create(Hand handPrefab)
    {
        var hand = Object.Instantiate(handPrefab);
        return hand;
    }
}
