using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Ant : MonoBehaviour
{

    public float _forwardSpeed;
    private float _swipeSpeed = 1; 
    [SerializeField]
    private float _maxLife = 100;
    [SerializeField]
    private float _minLife = 0;
    public ManagerUI managerUI;
    private Vector2 _startPosition;
    Vector2 _endPosition;
    Vector2 _direction;
    int _swipePositionCount = 0;
    float swipePowerUp;
    [SerializeField]
    private ParticleSystem _damageParticles;
    Controller _controller;
    Movement _movement;
    Model _model;
    [NonSerialized]
    public View _view;

    private FunctionalController _functionalController;
    
    
    void Awake()
    {
        _model = new Model(_forwardSpeed, _swipeSpeed, _maxLife, _minLife, transform,this, _damageParticles);
        _view = new View(_model);
        _movement = new Movement(_model);
        _controller = new Controller(this, _movement);
        _functionalController = gameObject.AddComponent<FunctionalController>();
        _functionalController.FunctionalControllerConstructor(_model, _movement);
        
        EventManager.Subscribe("GameOver", _functionalController.Dead);
        EventManager.Subscribe("FasterPowerUp", PowerUpMovement);
        
        _functionalController.OnHudLife += _view.UpdateHudLife;
        _functionalController.OnDamge += _view.TakeDamage;
    }
    private void Start()
    {
        SwipeManager2.instance.OnStartTouch += _controller.StartTouch;
        SwipeManager2.instance.OnEndTouch += _controller.EndTouch;
        _forwardSpeed = 0;
        EventManager.Subscribe("FastPowerUp", SpeedPowerUp);
        EventManager.Subscribe("EndPowerUp", SpeedPowerUp);
        swipePowerUp = -4.7f;
        transform.position = new Vector3(0, 0.063f, gameObject.transform.position.z);
        
    }
    void FixedUpdate()
    {
        ForwardMovemnt(_forwardSpeed);

        _controller.OnUpdate();
    }
    public void SpeedPowerUp(params object[] n1)
    {
        swipePowerUp = swipePowerUp + 1;
        _forwardSpeed += (float)n1[0];
    }

    public void ForwardMovemnt(float _speed)
    {
        transform.position += Vector3.forward * _speed * Time.deltaTime;
    }
    public void PowerUpMovement(params object[] parameters)
    {
        transform.position += Vector3.forward * _forwardSpeed * Time.deltaTime;
    }

}
