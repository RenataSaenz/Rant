using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingState : IState
{
    StateMachine _fsm;
    private PlayerModel _target;

    private int stop = 1;
    private Bee _bee;
    
    public AttackingState(StateMachine fsm, Bee b)
    {
        _fsm = fsm;
        _bee = b;
        _target = _bee.target;
    }

    public void OnStart()
    {
        Debug.Log("Attacking");
    }

    public void OnUpdate()
    {
        FieldOfAttack();
        
       
    }

    public void OnExit()
    {
    }
    
    public void FieldOfAttack()
    {
        Vector3 dirToTarget = (_target.transform.position - _bee.transform.position);
        
        if (Vector3.Angle(_bee.transform.forward, dirToTarget.normalized) < _bee.attackRange / 2)
        {
            
            if (_bee.InSight(_bee.transform.position, _target.transform.position))
            {
                Attack();
            }
            else
            {
                _fsm.ChangeState(PlayerStatesEnum.Idle);
            }

        }
    }

    void Attack()
    {
        
        /*_bee.m_Animator.SetTrigger("Attack");
        _bee._particles.Play();
        if(_bee.damageable!=null)
            _bee.damageable.SubtractLifeFunc(_bee._damage);*/
        
        /*var damageable = trig.transform.gameObject.GetComponent<IDamageable>();
        if (damageable != null)
        {
            _bee.m_Animator.SetTrigger("Attack");
            _bee._particles.Play();
            damageable.SubtractLifeFunc(_bee._damage);
        }*/
    }

    
    
}