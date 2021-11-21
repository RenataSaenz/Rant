using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class Floor : MonoBehaviour
{
    private FloorManager manager;
    [SerializeField]
    private int _numberOfObstacles = 7;
    [SerializeField]
    private GameObject[] obstacles;
    [SerializeField]
    private GameObject[] food;
    [SerializeField]
    private GameObject[] powerUps;
    [SerializeField]
    private GameObject[] enemies;
    [SerializeField]
    private Transform[] obstaclesPositions;
    [SerializeField]
    private Transform[] foodPositions;
    private List<int> ObstaclesNumbersList = new List<int>();
    private List<int> FoodNumbersList = new List<int>(); 
    [SerializeField]
    private float speed = 5f;
    float minDist = 0;
    private float _initialPosZ;
    [SerializeField]
    private int _floorSize = 30;
    Action _ArtificialFloor;

    private void Awake()
    {
        transform.position = Vector3.zero;
        _ArtificialFloor = NewFloor;
    }

    private void Update()
    {
        transform.position += -transform.forward * speed * Time.deltaTime;

        if (transform.position.z <= minDist)
        {
            _ArtificialFloor();
        }
    }

    void NewFloor()
    {
        manager.NewFloor();
        minDist = -(_floorSize*1.5f); //distancia en desaparecer el ult
        _ArtificialFloor = ReturnFloor;
    }

    void ReturnFloor()
    {
        minDist = _initialPosZ;
        manager.ReturnFloor(this);
        minDist = 0;
    }

    public static void TurnOff(Floor floor)
    {
        floor.gameObject.SetActive(false);
    }

    public static void TurnOn(Floor floor)
    {
        floor.gameObject.SetActive(true);
    }

    public void InitializeFloor(FloorManager m, int t)
    {
        _initialPosZ = t;

        foreach (var p in powerUps)
        {
            p.SetActive(false);
        }

        foreach (var o in obstacles)
        {
            o.SetActive(false);
        }
        foreach (var f in food)
        {
            f.SetActive(false);
        }
        foreach (var e in enemies)
        {
            e.SetActive(false);
        }
        manager = m;
        transform.position = new Vector3(0, 0, t);
        _ArtificialFloor = NewFloor;
        //minDist = 0
    }
    public void MiddleFloor(FloorManager m, int t)
    {
        InitializeFloor(m, t);
        
        var randomObstacles = Random.Range(_numberOfObstacles, obstacles.Length);
        var randomPowerUps = Random.Range(2, obstacles.Length);
        var randomFood = Random.Range(2, food.Length);
        
        ObstaclesNumbersList = new List<int>(new int[obstaclesPositions.Length]);
        FoodNumbersList = new List<int>(new int[foodPositions.Length]);

        for (int o = 0; o < randomObstacles; o++)
        {
             var randomObstaclesPositions = Random.Range(1, (obstaclesPositions.Length) + 1);

             while (ObstaclesNumbersList.Contains(randomObstaclesPositions))
             {
                randomObstaclesPositions = Random.Range(1, (obstaclesPositions.Length) + 1);
             }

             ObstaclesNumbersList[o] = randomObstaclesPositions;

             Vector3 pos = transform.position;
             pos = (obstaclesPositions[ObstaclesNumbersList[o] - 1]).transform.position;
            var index = Random.Range(0, obstacles.Length);
            //var instance = Instantiate(obstacles[index], pos, Quaternion.identity);
            //instance.transform.parent = gameObject.transform;
            obstacles[index].transform.position = pos;
            obstacles[index].SetActive(true);
        }

        for (int i = 0; i < randomPowerUps; i++)
        {
            var index = Random.Range(0, powerUps.Length);
            powerUps[index].SetActive(true);
        }

        for (int f = 0; f < randomFood; f++)
        {
            var randomFoodPositions = Random.Range(1, (foodPositions.Length) + 1);

            while (FoodNumbersList.Contains(randomFoodPositions))
            {
                randomFoodPositions = Random.Range(1, (foodPositions.Length) + 1);
            }

            FoodNumbersList[f] = randomFoodPositions;

            Vector3 pos = transform.position;
            pos = (foodPositions[FoodNumbersList[f] - 1]).transform.position;
            var index = Random.Range(0, food.Length);
            //var instance = Instantiate(obstacles[index], pos, Quaternion.identity);
            //instance.transform.parent = gameObject.transform;
            food[index].transform.position = pos;
            food[index].SetActive(true);
        }
    }
    public void MiddleFloorEnemy(FloorManager m, int t)
    {
        MiddleFloor(m,t);
        var randomEnemies = Random.Range(1, food.Length);

        for (int i = 0; i < randomEnemies; i++)
        {
            var index = Random.Range(0, enemies.Length);
            enemies[index].SetActive(true);
        }

    }
    public void FinishFloor(FloorManager m, int t)
    {
        InitializeFloor(m, t);
    }

}
