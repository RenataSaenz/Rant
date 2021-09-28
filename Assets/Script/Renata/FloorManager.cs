using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    public Transform initialPos; //utilizar para pasar el valor 0 del position

    public Floor prefab;
    [SerializeField]
    private GameObject _player;
    public Pool<Floor> pool;

    private void Awake()
    {
        FloorFactory _factory = new FloorFactory();
        pool = new Pool<Floor>(Create, Floor.TurnOff, Floor.TurnOn, 1);
    }

    private void Start()
    {
        NewFloor();
    }

    public void NewFloor()
    {
        pool.Get().InitialFloor(this); //aca pasar initialPos.position, luego de this
    }

    public void ReturnFloor (Floor floor)
    {
        pool.Return(floor);
    }
    public Floor Create()
    {
        return Instantiate(prefab);
    }
   
}
