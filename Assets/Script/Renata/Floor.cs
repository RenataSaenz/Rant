using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Floor : MonoBehaviour
{
    private FloorManager manager;
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
            //ReturnFloor();
            _ArtificialFloor();
        }
    }

    void NewFloor()
    {
        manager.NewFloor();
        minDist = -80;
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

    public void InitialFloor(FloorManager f)
    {
        manager = f;
        transform.position = Vector3.zero; // pasar la posicion por parametro
        _ArtificialFloor = NewFloor;
        minDist = -20;
        
    }

}
