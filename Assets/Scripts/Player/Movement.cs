using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement
{
    Transform _transform;
    float _swipeSpeed;
    float _jumpForce;
    Rigidbody _rb;
    public Movement(Transform t, float swipeSpeed, float jumpForce, Rigidbody rb)
    {
        _transform = t;
        _swipeSpeed = swipeSpeed;
        _jumpForce = jumpForce;
        _rb = rb;
    }
    public void Jump()
    {
        _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
    }

    public void Move(float h)
    {
        _transform.position += _transform.right * h * _swipeSpeed * Time.deltaTime;
    }
    /*
    public void Run(float v, float h)
    {
        _transform.position += _camTransform.forward * v * (_speed * 1.2f) * Time.deltaTime;
        _transform.position += _camTransform.right * h * (_speed * 1.2f) * Time.deltaTime;
    }*/
}
