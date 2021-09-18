using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float _speed = 1;
    private float _sidesSpeed = 1;
    //private Vector3 _movementInput;

    //usar observer para que agarre el moviemiento en h de la camara
    void Start()
    {
        //_movementInput.x = Input.GetAxis("Horizontal");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
        //transform.position += transform.right * _movementInput.x * _sidesSpeed * Time.deltaTime;
    }
}
