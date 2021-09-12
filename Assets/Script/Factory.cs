using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//creo dos factory:
//Uno no requiere ningun prefab y el otro tiene dos tipos de generics.

public interface IFactory<T>
{
    T Create(T parameter);
}

public interface IFactory<T, P>
{
    T Create(P parameter);
}
public class FoodFactory : IFactory<GameObject>
{
    public GameObject Create(GameObject foodPrefab)
    {
        var food = Object.Instantiate(foodPrefab);
        return food;
    }
}
