using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolingState : IState
{
    StateMachine _fsm;
    Animator _anim;
    private GameObject _target;

    private Wasp _enemy;
    
    
    public PatrolingState(StateMachine fsm, Wasp w)
    {
        _fsm = fsm;
        _enemy = w;
    }

    public void OnStart()
    {
    }

    public void OnUpdate()
    {
        _enemy.WayPoints();
        FieldOfView();
        
    }

    public void OnExit()
    {
    }

    public void FieldOfView()
    {
        Collider[] targetsInViewRadius = Physics.OverlapSphere(_enemy.transform.position, _enemy.viewRadius, _enemy.detectableAgentMask);
        
        foreach (var item in targetsInViewRadius)
        {
            Vector3 dirToTarget = (item.transform.position - _enemy.transform.position);

            if (Vector3.Angle(_enemy.transform.forward, dirToTarget.normalized) < _enemy.viewAngle / 2)
            {
                if (_enemy.InSight(_enemy.transform.position, item.transform.position))
                {
                    _fsm.ChangeState(PlayerStatesEnum.Shoot);
                }
            }
        }
        
        
        
        

    }
    
    
    
}