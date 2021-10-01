using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFactory<T>
{
    T Create(T parameter);
}

public class FoodFactory : IFactory<Food>
{
    public Food Create(Food foodPrefab)
    {
        var food = Object.Instantiate(foodPrefab);
        return food;
    }
}

public class FloorFactory : IFactory<Floor>
{
    public Floor Create(Floor floorPrefab)
    {
        var floor = Object.Instantiate(floorPrefab);
        return floor;
    }
}
