using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingState : IState
{
    StateMachine _fsm;
    private PlayerModel _target;

    private int stop = 1;
    private Bee _bee;
    
    public ChasingState(StateMachine fsm, Bee b)
    {
        _fsm = fsm;
        _bee = b;
        _target = _bee.target;
    }

    public void OnStart()
    {
        Debug.Log("Chasing");
    }

    public void OnUpdate()
    {
        FieldOfView();
    }

    public void OnExit()
    {
    }

   /* public void ChaseDir()
    {
        Vector3 dirToTarget = (_target.transform.position - _bee.transform.position);
        _bee.Movement(dirToTarget);
    }*/
    
    public void FieldOfView()
    {  
        Vector3 dirToTarget = (_target.transform.position - _bee.transform.localPosition);

        if (Vector3.Angle(_bee.transform.forward, dirToTarget.normalized) < _bee.viewAngle / 2)
        { 
            if (_bee.InSight(_bee.transform.position, _target.transform.position))
            {
                Debug.DrawLine(_bee.transform.position, _target.transform.position, Color.red);
                Debug.Log("InsideView, start chasing");
                //FieldOfAttack();
                _bee.Chase();
            }
            else if (!_bee.InSight(_bee.transform.position, _target.transform.position))
            {
                //_fsm.ChangeState(PlayerStatesEnum.Idle);
                
                /*_bee.transform.position = _bee.honey.transform.position + new Vector3(0, 0.4f, 0.7f);
                /*if(_bee.transform.position == _bee.honey.transform.position + new Vector3(0, 0.4f, 0.7f))
                    _fsm.ChangeState(PlayerStatesEnum.Idle);*/
            }
           
            
        }
        else
        {
          //  _fsm.ChangeState(PlayerStatesEnum.Idle);
        }
    }

    public void FieldOfAttack()
    {
        Vector3 dirToTarget = (_target.transform.position - _bee.transform.position);
        
        if (Vector3.Angle(_bee.transform.forward, dirToTarget.normalized) < _bee.attackRange / 2)
        { 
            if (_bee.InSight(_bee.transform.position, _target.transform.position))
            {
                //_fsm.ChangeState(PlayerStatesEnum.Attack);
            }

        }
    }
    
}

