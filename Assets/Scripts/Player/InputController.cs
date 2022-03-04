using System.Collections;
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
    int side = 1;
    
    
    //public event Action <Vector2, Vector2> OnMoving;
    

    public InputController(PlayerModel playerModel, Movement m)
    {
        _playerModel = playerModel;
        _movement = m;
        controlsMethod = NormalControls;
        
        //OnMoving += _movement.CalculateMovement;
    }

    public void OnUpdate()
    {
        _movementInput.x = Input.GetAxis("Horizontal");
        _movementInput.y = Input.GetAxis("Vertical");
        
        if (_movementInput.x != 0)
           _movement.Move( _movementInput.x);

        if (Input.GetKeyDown(KeyCode.F))
            _playerModel.weapons[_weaponIndex].Shoot();
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            _weaponIndex++;
            if (_weaponIndex >= _playerModel.weapons.Count) _weaponIndex = 0;
        }

        WeaponInUse();
        controlsMethod();
        // if (_endPosition!=null && _startPosition!=null) 
       // 
      // _movement.CalculateSwipePosition(side);
        
#if UNITY_ANDROID && !UNITY_EDITOR

        _movement.CalculateSwipePosition(_endPosition, _startPosition);
#endif
        
    }
    void WeaponInUse()
    {
        foreach (var weapon in _playerModel.weapons) 
            if (weapon == _playerModel.weapons[_weaponIndex]) weapon.TurnOn();
            else weapon.TurnOff();
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
