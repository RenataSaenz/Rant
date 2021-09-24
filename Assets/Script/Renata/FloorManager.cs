using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    public Floor floor;
    [SerializeField]
    private GameObject _player;
    public Pool<Floor> pool;

    private void Awake()
    {
        FloorFactory _factory = new FloorFactory();
        pool = new Pool<Floor>(Create, Floor.TurnOff, Floor.TurnOn, 1);
    }

    private void Update()
    {
        FloorUpdate();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlaceFloor();
        }
    }
    private void FloorUpdate()
    {
        bool _spawnFloor = Floor.spawnFloor;

         if (_spawnFloor == true)
         {
            pool.Get();
            floor.InitialFloor(pool);
            Floor.spawnFloor = false;
         }
    }
    public Floor PlaceFloor()
    {
        FloorFactory _factory = new FloorFactory();
        var floorObj = _factory.Create(floor);
        return floorObj;
    }
    public Floor Create()
    {
        return PlaceFloor();
    }
   
}
