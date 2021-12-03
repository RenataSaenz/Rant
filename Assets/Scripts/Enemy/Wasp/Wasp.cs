using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Wasp : MonoBehaviour
{
    [Header("Stats")]
    private Vector3 _velocity;
    public float maxSpeed;
    //private float maxForce;
    public Transform shootPoint;
    [SerializeField]private float _fireRate;
    
    private float _restartTimeToShoot;
    
    [Header("Field of View")]
    public float viewRadius;
    public float viewAngle;
    public LayerMask obstacleMask;
    public LayerMask detectableAgentMask;  //player mask
    
    [Header("WayPoints")]
    public List<Transform> wayPoints = new List<Transform>();
    [NonSerialized] public int _wayPointIndex = 0;
    
    [Header("Bullet")]
    [SerializeField]protected float _speed;
    [SerializeField]protected float _damage;
    [SerializeField]protected ParticleSystem _explosionParticles;
    [SerializeField]protected Mesh _mesh;
    [SerializeField]protected Material _material;
    [SerializeField]protected LayerMask _target;
    
    private StateMachine _fsm;

    private void Awake()
    {
       // maxForce = FlyweightPointer.Enemy.maxForce;
        _restartTimeToShoot = _fireRate;
        
        _fsm = new StateMachine();
        _fsm.AddState(PlayerStatesEnum.Patrol, new PatrolingState(_fsm, this));
        _fsm.AddState(PlayerStatesEnum.Shoot, new ShootingState(_fsm, this));
        _fsm.ChangeState(PlayerStatesEnum.Patrol);
        
    }

    void FixedUpdate()
    {
        _fsm.OnUpdate();
    }

    public void Shoot()
    {
        _fireRate -= Time.deltaTime;
        if (_fireRate < 0)
        {
            BulletSpawner.instance.bulletBuilder.Damage(_damage);
            BulletSpawner.instance.bulletBuilder.Speed(_speed);
            BulletSpawner.instance.bulletBuilder.Material(_material);
            BulletSpawner.instance.bulletBuilder.Mesh(_mesh);
            BulletSpawner.instance.bulletBuilder.Particles(_explosionParticles);
            BulletSpawner.instance.bulletBuilder.ShootPoint(shootPoint);
            BulletSpawner.instance.bulletBuilder.Target(_target);
            
            BulletSpawner.instance.Spawn();
            
            // Bullet.bulletBuilder.Damage(_damage);
            // Bullet.bulletBuilder.Speed(speed);
            // Bullet.bulletBuilder.Material(_material);
            // Bullet.bulletBuilder.Mesh(_mesh);
            // Bullet.bulletBuilder.Particles(_explosionParticles);
            // BulletSpawner.instance.Spawn(shootPoint);
            
            _fireRate = _restartTimeToShoot;
        }
    }
    public void WayPoints()
    {
        Vector3 desired = wayPoints[_wayPointIndex].transform.position - transform.position;
        
        if (desired.magnitude < 0.15f)
        {
            _wayPointIndex++;
            if (_wayPointIndex >= wayPoints.Count)
                _wayPointIndex = 0;
        }
        desired.Normalize();
        desired *= maxSpeed;

        Vector3 steering = Vector3.ClampMagnitude(desired - _velocity, FlyweightPointer.Enemy.maxForce);

        ApplyForce(steering);
        
        transform.position += _velocity * Time.deltaTime;
        transform.forward = _velocity;
        //return steering;
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
        Gizmos.DrawWireSphere(transform.position, viewRadius);

        Vector3 lineA = DirFromAngle(viewAngle / 2 + transform.eulerAngles.y);
        Vector3 lineB = DirFromAngle(-viewAngle / 2 + transform.eulerAngles.y);

        Gizmos.DrawLine(transform.position, transform.position + lineA * viewRadius);
        Gizmos.DrawLine(transform.position, transform.position + lineB * viewRadius);

    }
    
    Vector3 DirFromAngle(float angle)
    {
        return new Vector3(Mathf.Sin(angle * Mathf.Deg2Rad), 0, Mathf.Cos(angle * Mathf.Deg2Rad));
    }
    public void ApplyForce(Vector3 force)
    {
        _velocity += force;
        _velocity = Vector3.ClampMagnitude(_velocity, maxSpeed);
    }


}