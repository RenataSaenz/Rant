using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Controller 
{
    Movement _movement;
    private Ant _ant;
    private Vector3 _movementInput;
    
    private Vector2 _startPosition;
    Vector2 _endPosition;
    //private int touchCount = 0;

    Action controlsMethod;

    public Controller(Ant ant, Movement m)
    {
        _movement = m;
        _ant = ant;
        controlsMethod = NormalControls;
    }

    public void OnUpdate()
    {
        _movementInput.x = Input.GetAxis("Horizontal");
        _movementInput.y = Input.GetAxis("Vertical");
        if (_movementInput.x != 0)
           _movement.Move( _movementInput.x);

        controlsMethod();
        
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
        _ant.managerUI.InactivePause();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Pausa");
            Time.timeScale = 0f;
            controlsMethod = PausedControls;
            _ant.managerUI.ActivePause();
        }

    }

    void PausedControls()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1f;
            controlsMethod = NormalControls;
            _ant.managerUI.InactivePause();
        }

    }
}
