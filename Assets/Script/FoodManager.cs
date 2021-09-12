using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : MonoBehaviour
{
    public GameObject foodPrefab;
    //private FoodFactory _factory;
  //  private IFactory<GameObject, GameObject> _factory = new FoodFactory();

    private void Awake()
    {
        var pool = new Pool<Food>(Create, 5);
    }

    private Food Create()
    {
        PlaceFood();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlaceFood();
        }
    }
    private void PlaceFood() {
        FoodFactory _factory = new FoodFactory();
        var food = _factory.Create(foodPrefab);
    }

}
