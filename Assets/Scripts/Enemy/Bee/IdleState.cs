using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    StateMachine _fsm;
    private PlayerModel _target;

    private int stop = 1;
    private Bee _bee;
    
    public IdleState(StateMachine fsm, Bee b)
    {
        _fsm = fsm;
        _bee = b;
        _target = _bee.target;
    }

    public void OnStart()
    { _bee.transform.position = _bee.honey.transform.position + new Vector3(0, 0.4f, 0.7f);
    }

    public void OnUpdate()
    {
        HoneyRound();
        FieldOfView();
    }

    public void OnExit()
    {
    }

    
    void HoneyRound()
    {
       
        _bee.m_Animator.SetBool("Moving", true);
        Vector3 honeyVec = _bee.honey.transform.position;
        _bee.transform.RotateAround(honeyVec, Vector3.up, 40 * Time.deltaTime * stop);
    }
    
    public void FieldOfView()
    {
        Vector3 dirToTarget = (_target.transform.position - _bee.transform.position);

        if (Vector3.Angle(_bee.transform.forward, dirToTarget.normalized) < _bee.viewAngle / 2)
        {
            if (_bee.InSight(_bee.transform.position, _target.transform.position))
            {
                _fsm.ChangeState(PlayerStatesEnum.Chase);
            }
        }

    }
    
}
