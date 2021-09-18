﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : MonoBehaviour
{
    
    public bool isDead;
    public int health = 1;
    private int currentHealth;
    public float dieTimer;

    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _swipeSpeed;
    [SerializeField]
    private float _jumpForce;
    [SerializeField]
    private Transform _camTransform;
    [SerializeField]
    private ForceMode jumpForceMode = ForceMode.Force;

    public ManagerUI managerUI;

    Control _control;
    Movement _movement;

    private Rigidbody _rb;

    void Awake()
    {
        EventManager.Subscribe("GameOver", Dead);

        _rb = GetComponent<Rigidbody>();

        _movement = new Movement(transform, _swipeSpeed, _jumpForce, _rb, _camTransform);
        _control = new Control(this, _movement);
        //playerAudio = GetComponent<PlayerAudio>();
        currentHealth = health;
    }

    void FixedUpdate()
    {
        transform.position += Vector3.forward * _speed * Time.deltaTime;
        _control.OnUpdate();
    }

    public void Dead(params object[] parameters)
    {
        _speed = 0;
        isDead = true;
        EventManager.Trigger("GameOver", dieTimer);
    }

    private void OnTriggerEnter(Collider other)
    {
        var obj = other.gameObject.GetComponent<ICollectable>();

        if (isDead == false & obj != null)
        {
            obj.Collect();
        }

        /*if (other.gameObject.layer == 8)
        {
            TakeDamage();
        } */
    }

}
