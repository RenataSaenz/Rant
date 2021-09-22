using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    private void Awake()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        transform.position += -transform.forward * speed * Time.deltaTime;
    }
    public static void TurnOff(Floor floor)
    {
        floor.gameObject.SetActive(false);
    }

    public static void TurnOn(Floor floor)
    {
        floor.gameObject.SetActive(true);
    }


}
