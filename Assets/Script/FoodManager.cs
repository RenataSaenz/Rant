using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public Food foodPrefab;

    private void Awake()
    {
        FoodFactory _factory = new FoodFactory();

        var pool = new Pool<Food>(Create, Food.TurnOff, Food.TurnOn, 5);

    }
    private Food Create()
    {
        return PlaceFood();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlaceFood();
        }
    }

    private Food PlaceFood() {
        FoodFactory _factory = new FoodFactory();
       var food = _factory.Create(foodPrefab);
        return food;
    }

}
