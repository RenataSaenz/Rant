using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Bee : MonoBehaviour
{
    [Header("Stats")]
    public Animator m_Animator;
    private Vector3 _velocity;
    [SerializeField]
    private int _damage = 5;
    [SerializeField]
    private float _maxSpeed;
    //private float _maxForce;
    private int _counter = 1;
    
    public ParticleSystem _particles;
    public PlayerModel target;
    public Transform honey;
   
    [Header("Field of View")]
    public float viewRadius;
    public float viewAngle;
    public float attackRange;
    public LayerMask obstacleMask;
    
    
    [NonSerialized]
    public IDamageable damageable;
    
    private StateMachine _fsm;
    
    private void Start()
    {
        //_maxForce = FlyweightPointer.Enemy.maxForce;
        
        _fsm = new StateMachine();
        
        _fsm.AddState(PlayerStatesEnum.Idle, new IdleState(_fsm,  this));
        _fsm.AddState(PlayerStatesEnum.Chase, new ChasingState(_fsm, this));
        _fsm.AddState(PlayerStatesEnum.Attack, new AttackingState(_fsm, this));
        
        
        //StartingPosition();
       //layer_mask = LayerMask.GetMask("Player");
       transform.position = honey.transform.position + new Vector3(0, 0.4f, 0.7f);
       _fsm.ChangeState(PlayerStatesEnum.Idle);
       
    }

    void OnTriggerStay(Collider trig)
    {
        //damageable = trig.transform.gameObject.GetComponent<IDamageable>();
        var damageable = trig.transform.gameObject.GetComponent<IDamageable>();
        int _counter = 1;
        if (damageable != null && _counter == 1)
        {
            m_Animator.SetTrigger("Attack");
            _particles.Play();
            damageable.SubtractLifeFunc(_damage);
            //stop = 0;
            _counter--;
            _fsm.ChangeState(PlayerStatesEnum.Idle);
           // StartCoroutine(WaitForRestart(2));
        }
    }
    IEnumerator WaitForRestart(float time)
    {
        yield return new WaitForSeconds(time);
        //Debug.Log("beeRestart");
       // stop = 1;
        transform.position = honey.transform.position + new Vector3(0, 0.4f, 0.7f);
    }

    private void Update()
    {
        _fsm.OnUpdate();
        transform.position += _velocity * Time.deltaTime;
        //transform.forward = _velocity;
    }

    public void Chase()
    {
        transform.LookAt(target.transform);
        
        Vector3 desired = (target.transform.position - transform.position);
        
        desired.Normalize();
        desired *= _maxSpeed;

        Vector3 steering = Vector3.ClampMagnitude(desired - _velocity, FlyweightPointer.Enemy.maxForce);

        ApplyForce(steering);
    }
    
    public bool InSight(Vector3 start, Vector3 end)
    {
        Vector3 dir = end - start;
        if (!Physics.Raycast(start, dir, dir.magnitude, obstacleMask))return true;
        else return false;
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.localPosition, viewRadius);
        Gizmos.DrawWireSphere(transform.localPosition, attackRange);

        Vector3 lineA = DirFromAngle(viewAngle / 2 + transform.eulerAngles.y);
        Vector3 lineB = DirFromAngle(-viewAngle / 2 + transform.eulerAngles.y);

        Gizmos.DrawLine(transform.localPosition, transform.localPosition + lineA * viewRadius);
        Gizmos.DrawLine(transform.localPosition, transform.localPosition + lineB * viewRadius);

    }
    Vector3 DirFromAngle(float angle)
    {
        return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad));
    }
   public void ApplyForce(Vector3 force)
   {
       _velocity += force;
       _velocity = Vector3.ClampMagnitude(_velocity, _maxSpeed);
   }
}
