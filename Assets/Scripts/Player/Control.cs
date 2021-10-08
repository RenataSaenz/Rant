using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Control 
{
    Movement _movement;
    private Ant ant;
    private Vector3 _movementInput;
    //private int touchCount = 0;

    Action controlsMethod;

    public Control(Ant controller, Movement m)
    {
        _movement = m;
        ant = controller;
        controlsMethod = NormalControls;
    }

    public void OnUpdate()
    {
#if UNITY_EDITOR
        _movementInput.x = Input.GetAxis("Horizontal");
        _movementInput.y = Input.GetAxis("Vertical");

        if (_movementInput.x != 0)
           _movement.Move( _movementInput.x);
        if (_movementInput.y >= 1)
            _movement.Jump();

#endif
        controlsMethod();

      
        /*
        if (touchCount == 0)
            _movement.Move1();
        if (touchCount == -1)
            _movement.Move2();
        if (touchCount == 1)
            _movement.Move3();*/
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
