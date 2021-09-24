using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    private Pool<Floor> _pool;
    public Floor floor;

    public static bool spawnFloor = false;
    private int _counter = 1;
    private void Awake()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        transform.position += -transform.forward * speed * Time.deltaTime;

        if (transform.position.z <= -5 && _counter == 1)
        {
            spawnFloor = true;
            _counter--;
        }
        
        if (transform.position.z <= -10)
        {
            _pool.Return(floor);
        }
    }
    public static void TurnOff(Floor floor)
    {
        floor.gameObject.SetActive(false);
    }

    public static void TurnOn(Floor floor)
    {
        floor.gameObject.SetActive(true);
    }

    public void InitialFloor(Pool<Floor> pool)
    {
        _pool = pool;
        floor = pool.Get();
    }

}
