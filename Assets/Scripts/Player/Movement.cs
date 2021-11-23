using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement 
{
    Transform _transform;
    public float _swipeSpeed;
    public float _forwardSpeed;
    int _swipePositionCount = 0;
    private Vector3 posLeft;
    private Vector3 posCenter;
    private Vector3 posRight;

    public Movement(PlayerModel playerModel)
    {
        _transform = playerModel.transform;
        _swipeSpeed = playerModel.swipeSpeed;
        _forwardSpeed = playerModel.forwardSpeed;
        
        posLeft = new Vector3(-1, _transform.position.y, _transform.position.z);
        posCenter = new Vector3(0, _transform.position.y, _transform.position.z);
        posRight = new Vector3(1, _transform.position.y, _transform.position.z);
    }

    public void Move(float h)
    {
        _transform.position += _transform.right * h *  _swipeSpeed * Time.deltaTime;
    }
    public void MoveForward(float maxDistanceUnits)
    {
        //_transform.position += _transform.up *  speed * Time.deltaTime;
        Vector3 target; 
        target.z = _transform.position.z + 1;

        if (_transform.position.z <= 6)
        {
            _transform.position = Vector3.MoveTowards(_transform.position,
                new Vector3(_transform.position.x, _transform.position.y, 6), maxDistanceUnits * Time.deltaTime);
        }
        else
        { _transform.position = Vector3.MoveTowards(_transform.position,
            new Vector3(_transform.position.x, _transform.position.y, -6), 700 * Time.deltaTime);
        }
    }
    

    public void CalculateSwipePosition(Vector2 _endPosition, Vector2 _startPosition)
    {
        
        float step = _swipeSpeed * Time.deltaTime;
        float dist = _endPosition.x - _startPosition.x;

        Vector3 distLeft = posLeft - _transform.position;
        Vector3 distCenter = posCenter - _transform.position;
        Vector3 distRight = posRight - _transform.position;

        if (_startPosition.x <= _endPosition.x) //swipe derecha
        { 
            _swipePositionCount +=1;
            if (_swipePositionCount >= 1)
                _swipePositionCount = 1; 
            
            // transform.position += new Vector3(1 * step, 0.063f, gameObject.transform.position.z);
            if (_transform.position.x <= posRight.x)
                _transform.position += _transform.right * step;
            

            if (Vector3.Distance(posCenter, _transform.position) < 0.001f || Vector3.Distance(posRight, _transform.position) < 0.001f)
            {
                _swipeSpeed = 0;
                return;
            }
        }
        if (_startPosition.x >= _endPosition.x) //swipe izq
        {  
            _swipePositionCount -=1;
            
            if (_swipePositionCount <= -1)
                _swipePositionCount = -1;
            
            if (_transform.position.x >= posLeft.x)
                _transform.position += -_transform.right * step;
            
            // transform.position += new Vector3(-1 * step, 0.063f, gameObject.transform.position.z);
            
           if (Vector3.Distance(  posCenter, _transform.position) < 0.001f || Vector3.Distance(posLeft, _transform.position) < 0.001f)
            {
                _swipeSpeed = 0;
                return;
            } 
        }
        _swipeSpeed = 1;
        /*
        if (_swipePositionCount == 0)
        {   
           transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, 0.063f, pos.z), _swipeSpeed * Time.deltaTime);
        }
        if (_swipePositionCount == 1)
        {
           transform.position = Vector3.MoveTowards(transform.position, new Vector3(1, 0.063f, pos.z), _swipeSpeed * Time.deltaTime);
        }
        if (_swipePositionCount == -1)
        {
           transform.position = Vector3.MoveTowards(transform.position, new Vector3(-1, 0.063f, pos.z), _swipeSpeed * Time.deltaTime);
        }*/
        
    }
  

}
