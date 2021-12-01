﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InputController 
{
    Movement _movement;
    PlayerModel _playerModel;
    private Vector3 _movementInput;
    Vector2 _startPosition;
    Vector2 _endPosition;
    //private int touchCount = 0;
    Action controlsMethod;
    int _weaponIndex = 0;

    public InputController(PlayerModel playerModel, Movement m)
    {
        _playerModel = playerModel;
        _movement = m;
        controlsMethod = NormalControls;
    }

    public void OnUpdate()
    {
        _movementInput.x = Input.GetAxis("Horizontal");
        _movementInput.y = Input.GetAxis("Vertical");
        if (_movementInput.x != 0)
           _movement.Move( _movementInput.x);

        if (Input.GetKeyDown(KeyCode.F))
        {
            _playerModel.weapons[_weaponIndex].Shoot();
            Debug.Log("shoot");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            _playerModel.weapons[_weaponIndex].TurnOff();
            _weaponIndex++;
            if (_weaponIndex >= _playerModel.weapons.Count)
                _weaponIndex = 0;
            _playerModel.weapons[_weaponIndex].TurnOn();
        }




        controlsMethod();
        
        //_movement.CalculateSwipePosition();
#if UNITY_ANDROID && !UNITY_EDITOR
        _movement.CalculateSwipePosition(_endPosition, _startPosition);
#endif
    }

    public void StartTouch(Vector2 position)
    {
        _startPosition = position;
    }
    public void EndTouch(Vector2 position)
    {
        _endPosition = position;
    }

    void NormalControls()
    {
        _playerModel.managerUI.InactivePause();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Pausa");
            Time.timeScale = 0f;
            controlsMethod = PausedControls;
            _playerModel.managerUI.ActivePause();
        }
    }

    void PausedControls()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1f;
            controlsMethod = NormalControls;
            _playerModel.managerUI.InactivePause();
        }
    }
}
