using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FloorManager : MonoBehaviour
{
<<<<<<< Updated upstream:Assets/Script/Renata/FloorManager.cs
    public Transform initialPos; //utilizar para pasar el valor 0 del position
=======
    //public Transform initialPos; //utilizar para pasar el valor 0 del position
    public int initialPosZ;
>>>>>>> Stashed changes:Assets/Scripts/Floor/FloorManager.cs

    public Floor prefab;

    [SerializeField]
    private FloorManager _firstFloor;
    [SerializeField]
    private FloorManager _lastFloor;

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
<<<<<<< Updated upstream:Assets/Script/Renata/FloorManager.cs
        pool.Get().InitialFloor(this); //aca pasar initialPos.position, luego de this
=======
        ActiveFloor();
>>>>>>> Stashed changes:Assets/Scripts/Floor/FloorManager.cs
    }

    public void ReturnFloor (Floor floor)
    {
        pool.Return(floor);
    }

    void InstantiateFloor()
    {
        _counter++;
        //if (_counter == 0)
        //    pool.Get().InitialFloor(_firstFloor, initialPosZ);
        if (_counter <= minFloors)
            pool.Get().InitialFloor(this, initialPosZ);
        else
        {
            pool.Get().FinishFloor(_lastFloor, initialPosZ);
           ActiveFloor = delegate { };        
       }

    }
    public Floor Create()
    {
        return Instantiate(prefab);
    }
   
}
