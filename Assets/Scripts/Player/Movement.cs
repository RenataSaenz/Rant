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
    public void CalculateSwipePosition(int wp)
    {
        if (wp != null) _swipePositionCount = wp;
            
            _transform.position = Vector3.MoveTowards(_transform.position, _playerModel._swipePoints[_swipePositionCount],
                _swipeSpeed * Time.deltaTime);
          
       
    }

    // public void CalculateSwipePosition(Vector2 _endPosition, Vector2 _startPosition)
    // {
    //
    //     if (_startPosition.x < _endPosition.x) //swipe derecha
    //     {
    //         
    //         //_transform.position = Vector3.MoveTowards(_transform.position,
    //           //  _playerModel._swipePoints[2], _swipeSpeed * Time.deltaTime);
    //         
    //         //_transform.position =  _playerModel._swipePoints[2];
    //         
    //         _transform.position = Vector3.MoveTowards(_transform.position, _playerModel._swipePoints[2],
    //             _swipeSpeed * Time.deltaTime);
    //         //
    //         // if (_swipePositionCount == 2) return;
    //         // _swipePositionCount += 1; 
    //         
    //     }
    //     if (_startPosition.x > _endPosition.x) //swipe izq
    //     {
    //       //  _transform.position = Vector3.MoveTowards(_transform.position,
    //        //     _playerModel._swipePoints[0], _swipeSpeed * Time.deltaTime);
    //         //_transform.position =  _playerModel._swipePoints[0];
    //         
    //         _transform.position = Vector3.MoveTowards(_transform.position, _playerModel._swipePoints[0],
    //             _swipeSpeed * Time.deltaTime);
    //        // if (_swipePositionCount == 0) return;
    //        // //  
    //        //  _swipePositionCount -= -1;
    //        //  
    //     }
    //     
    //    
    //     //Vector3 dir = _playerModel._swipePoints[_swipePositionCount] - _transform.position;
    //   //  _transform.position +=  dir * _swipeSpeed * Time.deltaTime;
    //    
    // }
}
