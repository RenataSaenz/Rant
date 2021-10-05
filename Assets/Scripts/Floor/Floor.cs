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
    private GameObject anthill;
    [SerializeField]
    private GameObject[] obstacles;
    [SerializeField]
    private GameObject[] powerUps;
    [SerializeField]
    private Transform[] obstaclesPositions;
    private List<int> TakeList = new List<int>();
    [SerializeField]
    private float speed = 5f;
    int minDist = -20;

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
        minDist = -50;
        _ArtificialFloor = ReturnFloor;
    }

    void ReturnFloor()
    {
        manager.ReturnFloor(this);
        minDist = -20;
    }

    public static void TurnOff(Floor floor)
    {
        floor.gameObject.SetActive(false);
    }

    public static void TurnOn(Floor floor)
    {
        floor.gameObject.SetActive(true);
    }

    public void InitializeFloor(FloorManager f, int t)
    {
        foreach (var p in powerUps)
        {
            p.SetActive(false);
        }

        foreach (var o in obstacles)
        {
            o.SetActive(false);
        }

        manager = f;
        transform.position = new Vector3(0, 0, t);
        _ArtificialFloor = NewFloor;
        minDist = -20;
    }
    public void MiddleFloor(FloorManager f, int t)
    {
        InitializeFloor(f, t);
        
        var randomObstacles = Random.Range(_numberOfObstacles, obstacles.Length);
        var randomPowerUps = Random.Range(2, obstacles.Length);
        TakeList = new List<int>(new int[obstaclesPositions.Length]);

        for (int o = 0; o < randomObstacles; o++)
        {
             var randomObstaclesPositions = Random.Range(1, (obstaclesPositions.Length) + 1);

             while (TakeList.Contains(randomObstaclesPositions))
             {
                randomObstaclesPositions = Random.Range(1, (obstaclesPositions.Length) + 1);
             }

             TakeList[o] = randomObstaclesPositions;

             Vector3 pos = transform.position;
             pos = (obstaclesPositions[TakeList[o] - 1]).transform.position;
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
    }
    public void FinishFloor(FloorManager f, int t)
    {
        anthill.SetActive(true);
        InitializeFloor(f, t);
    }

}
