using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Control 
{
    private Ant ant;
    

    Action controlsMethod;

    public Control(Ant controller)
    {
        ant = controller;
        controlsMethod = NormalControls;
    }

    public void OnUpdate()
    {
        controlsMethod();
    }

    void NormalControls()
    {
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
