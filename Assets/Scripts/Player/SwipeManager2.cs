using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[DefaultExecutionOrder(-1)]
public class SwipeManager2 : MonoBehaviour
{
    public static SwipeManager2 instance;

    public delegate void StartTouch(Vector2 position);
    public event StartTouch OnStartTouch;

    public delegate void UpdateTouch(Vector2 position);
    public event UpdateTouch OnUpdateTouch;

    public delegate void EndTouch(Vector2 position);
    public event EndTouch OnEndTouch;

    Camera _cam;
    Action _ArtificialUpdate;
    int _idTouch;
    Vector2 _actualPos;
    bool _started;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _cam = Camera.main;
        _ArtificialUpdate = StartTouchPrimary;
    }

    private void  FixedUpdate()
    {
        _ArtificialUpdate();
    }

    void StartTouchPrimary()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            _idTouch = touch.fingerId;

            _actualPos = GetWorldPositionPlane(touch.position);

            //_actualPos = _cam.ScreenToWorldPoint(touch.position);

            if (OnStartTouch != null)
            {
                OnStartTouch(_actualPos);
            }
            _ArtificialUpdate = UpdateTouchPrimary;
        }
    }
    
    void UpdateTouchPrimary()
    {
        if (Input.touchCount > 0)
        {
            if (OnUpdateTouch != null)
            {
                var touch = Input.GetTouch(0);

                if (touch.fingerId == _idTouch)
                {
                    _actualPos = GetWorldPositionPlane(touch.position);
                    //_actualPos = _cam.ScreenToWorldPoint(touch.position);  //esto es si esta orthographic
                    OnUpdateTouch(_actualPos);
                }
                else
                    _ArtificialUpdate = EndTouchPrimary;
            }
        }
        else
            _ArtificialUpdate = EndTouchPrimary;
    }

    void EndTouchPrimary()
    {
        if (OnEndTouch != null)
        {
            //_actualPos = _cam.ScreenToWorldPoint(touch.position);
            OnEndTouch(_actualPos);
        }

        _ArtificialUpdate = StartTouchPrimary;

    }
    
    Vector3 GetWorldPositionPlane(Vector3 screenPos)
    {
        if (_cam.orthographic)
            return _cam.ScreenToWorldPoint(screenPos);

        Ray ray = _cam.ScreenPointToRay(screenPos);
        Plane xy = new Plane(Vector3.forward, Vector3.zero);
        float dist;
        xy.Raycast(ray, out dist);
        return ray.GetPoint(dist);
    }
}
