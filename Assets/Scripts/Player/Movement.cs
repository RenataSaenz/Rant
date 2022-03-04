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
    private Vector3 startPos;
    private Vector2 _startPosition;
    private Vector2 _endPosition;

    public Movement(PlayerModel playerModel)
    {
        _startPosition = new Vector2(0, 0);
        _endPosition = new Vector2(0, 0);
        _playerModel = playerModel;
        _transform = playerModel.transform;
        _swipeSpeed = playerModel.swipeSpeed;
        _forwardSpeed = playerModel.forwardSpeed;
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
    // public void CalculateSwipePosition(Vector2 endPos, Vector2 startPos)
    // {
    //     if (_startPosition.x < _endPosition.x)
    //     {
    //         Vector3 dir = _playerModel._swipePoints[2] - _transform.position; 
    //         _transform.position +=  dir * _swipeSpeed * Time.deltaTime;
    //     }
    //        
    //     if (_startPosition.x > _endPosition.x)
    //     {
    //         Vector3 dir = _playerModel._swipePoints[0] - _transform.position; 
    //         _transform.position +=  dir * _swipeSpeed * Time.deltaTime;
    //     }
    // }

    // public void CalculateMovement(Vector2 startPos, Vector2 endPos)
    // {
    //         if (startPos.x < endPos.x && _swipePositionCount!=2) _swipePositionCount +=1;
    //         if (startPos.x > endPos.x&& _swipePositionCount!=0) _swipePositionCount -= 1;
    //         
    //         
    //         _transform.position = Vector3.MoveTowards(_transform.position, _playerModel._swipePoints[_swipePositionCount],
    //             _swipeSpeed * Time.deltaTime);
    //
    // }
    

    public void CalculateSwipePosition(Vector2 _endPosition, Vector2 _startPosition)
    {
    
        if (_startPosition.x < _endPosition.x) //swipe derecha
        {
            
            _transform.position = Vector3.MoveTowards(_transform.position, _playerModel._swipePoints[2],
                _swipeSpeed * Time.deltaTime);
            
        }
        if (_startPosition.x > _endPosition.x) //swipe izq
        {
            
            _transform.position = Vector3.MoveTowards(_transform.position, _playerModel._swipePoints[0],
                _swipeSpeed * Time.deltaTime);
        }
        
       
        //Vector3 dir = _playerModel._swipePoints[_swipePositionCount] - _transform.position;
      //  _transform.position +=  dir * _swipeSpeed * Time.deltaTime;
       
    }
}
