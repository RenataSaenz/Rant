using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FloorManager : MonoBehaviour
{
    public int initialPosZ = 0;

    public Floor prefab;

    public Pool<Floor> pool;

    public int minFloors;
    int _counter;

    Action ActiveFloor;
    

    private void Awake()
    {
        FloorFactory _factory = new FloorFactory();
        pool = new Pool<Floor>(Create, Floor.TurnOff, Floor.TurnOn, 1);
        ActiveFloor = InstantiateFloor;
    }

    private void Start()
    {
        NewFloor();
    }

    public void NewFloor()
    {
       // pool.Get().InitialFloor(this, initialPosZ); 
        ActiveFloor();
    }

    public void ReturnFloor (Floor floor)
    {
        pool.Return(floor);
    }

    void InstantiateFloor()
    {
        _counter++;
        int _floorSize = 30;
        if (_counter == 1)
        {
            pool.Get().InitializeFloor(this, initialPosZ);
        }
        else if (_counter > 1 && _counter <= minFloors)
        {
            if(_counter%2==1)
            {
                pool.Get().MiddleFloorEnemy(this, initialPosZ + _floorSize);
            }
            else
            {
                pool.Get().MiddleFloor(this, initialPosZ + _floorSize);
            }
        }
        else if (_counter == (minFloors + 1))
        {
            pool.Get().FinishFloor(this, initialPosZ + _floorSize);
        }
        else
        {
            ActiveFloor = delegate { };
        }
    }
    public Floor Create()
    {
        return Instantiate(prefab);
    }
   
}
