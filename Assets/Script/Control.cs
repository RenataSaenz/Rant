using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Control 
{
    Movement _movement;
    private Ant ant;
    private Vector3 _movementInput;
    

    Action controlsMethod;

    public Control(Ant controller, Movement m)
    {
        _movement = m;
        ant = controller;
        controlsMethod = NormalControls;
    }

    public void OnUpdate()
    {
        _movementInput.x = Input.GetAxis("Horizontal");
        _movementInput.y = Input.GetAxis("Vertical");

        controlsMethod();

        if (_movementInput.x != 0)
            _movement.Move( _movementInput.x);
        if (_movementInput.y >= 1)
            _movement.Jump();
    }

    void NormalControls()
    {
        ant.managerUI.InactivePause();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Pausa");
            Time.timeScale = 0f;
            controlsMethod = PausedControls;
            ant.managerUI.ActivePause();
        }

    }

    void PausedControls()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1f;
            controlsMethod = NormalControls;
            ant.managerUI.InactivePause();
        }

    }
}
