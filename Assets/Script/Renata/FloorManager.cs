using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    public Floor[] floors;
    public int floorIndex = 0;
    [SerializeField]
    private GameObject _player;

    private void Awake()
    {
        FloorFactory _factory = new FloorFactory();
        var pool = new Pool<Floor>(Create, Floor.TurnOff, Floor.TurnOn, 1);
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
    {   //(Vector3.Distance(floors[floorIndex].transform.position, transform.position) < 0.1f)
       
        if (floors[floorIndex].transform.position.z <= -10)
        {
            floorIndex++;
            PlaceFloor();
        }
    }
    private Floor PlaceFloor()
    {
        FloorFactory _factory = new FloorFactory();
        var floor = _factory.Create(floors[floorIndex]);
        return floor;
    }
    private Floor Create()
    {
        return PlaceFloor();
    }
}
