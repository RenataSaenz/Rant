using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement 
{
    Transform _transform;
    private PlayerModel _playerModel;
    public float _swipeSpeed;
    public float _forwardSpeed;
    int _swipePositionCount = 1;
    private Vector3 posLeft;
    private Vector3 posCenter;
    private Vector3 posRight;
    private Vector3 startPos;
    

    public Movement(PlayerModel playerModel)
    {
        _playerModel = playerModel;
        _transform = playerModel.transform;
        _swipeSpeed = playerModel.swipeSpeed;
        _forwardSpeed = playerModel.forwardSpeed;
        
        posLeft = new Vector3(-1, _transform.position.y, _transform.position.z);
        posCenter = new Vector3(0, _transform.position.y, _transform.position.z);
        posRight = new Vector3(1, _transform.position.y, _transform.position.z);
        
        startPos.z = _playerModel.InitialPosition.z ;
        
    }
    public void Move(float h)
    {
        _transform.position += _transform.right * h *  _swipeSpeed * Time.deltaTime;
    }
    public void MoveForward(float maxDistanceUnits)
    {
        if (_transform.position.z < 4)
        {
            _transform.position = Vector3.MoveTowards(_transform.position,
                new Vector3(_transform.position.x, _transform.position.y, 4), maxDistanceUnits * Time.deltaTime);
        }
        else
        {
            _transform.position = Vector3.MoveTowards(_transform.position,
            new Vector3(_transform.position.x, _transform.position.y,  startPos.z), 700 * Time.deltaTime);
        }
    }

    public void CalculateSwipePosition(Vector2 _endPosition, Vector2 _startPosition)
    {
/*
        float step = _swipeSpeed * Time.deltaTime;
        float dist = _endPosition.x - _startPosition.x;

        Vector3 distLeft = posLeft - _transform.position;
        Vector3 distCenter = posCenter - _transform.position;
        Vector3 distRight = posRight - _transform.position;*/

        if (_startPosition.x <= _endPosition.x) //swipe derecha
        { 
            if (_swipePositionCount < 1)
                _swipePositionCount += 1; 
            

            /*if (Vector3.Distance(posCenter, _transform.position) < 0.001f || Vector3.Distance(posRight, _transform.position) < 0.001f)
            {
                _swipeSpeed = 0;
                return;
            }*/
        }
        if (_startPosition.x >= _endPosition.x) //swipe izq
        {  
            if (_swipePositionCount > -1)
                _swipePositionCount -= -1;
            
        }
        
        Vector3 dir = _playerModel._swipePoints[_swipePositionCount] - _transform.position;
        _transform.forward = dir;
        _transform.position +=  dir * _swipeSpeed * Time.deltaTime;
    }
  

}
