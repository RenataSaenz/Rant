using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    public Animator m_Animator;

    public Ant target;

    private Vector3 _velocity;

    private int _counter = 1;

    [SerializeField]
    private ParticleSystem _particles;

    [SerializeField]
    private int _damage = 5;
    [SerializeField]
    private float maxSpeed;
    [SerializeField]
    private float maxForce;
    [SerializeField]
    private float _nextAttack = 5;
    [SerializeField]
    private float startMaxSpeed;

    float m_MaxDistance = 4;
    bool m_HitDetect;
    public Collider m_Collider;
    RaycastHit m_Hit;

    public Transform honey;
    private Vector3 honeyVec;
    private float stop = 1;

    // private Vector3 target1 = new Vector3(5.0f, 0.0f, 0.0f);
    private void Start()
    {
        StartingPosition();
    }

    private void Update()
    {
       m_HitDetect = Physics.BoxCast(m_Collider.bounds.center, transform.localScale, transform.forward, out m_Hit, transform.rotation, m_MaxDistance);

        if (!m_HitDetect)
        {
            HoneyRound();
        }
        else
        {
            Seek();

            transform.position += _velocity * Time.deltaTime * stop;
            transform.forward = _velocity;
        }

            
    }

    void Seek()
    {
        m_Animator.SetBool("Moving", true);

        Vector3 desired = target.transform.position - transform.position;
        
        desired.Normalize();  //si queremos que vaya mas rapido cuanto mas lejos y no constante, borrar el normalizado.
        desired *= maxSpeed;

        Vector3 steering = desired - _velocity;
        steering = Vector3.ClampMagnitude(steering, maxForce);  //para que gire constantemente a la fuerza que le queremos dar

        ApplyForce(steering);
    }

    void HoneyRound()
    {
        m_Animator.SetBool("Moving", true);
        Vector3 honeyVec = honey.transform.position;

        transform.RotateAround(honeyVec, Vector3.up, 90 * Time.deltaTime * stop);
    }

    void ApplyForce(Vector3 force)
    {
        _velocity += force;
    }

    void OnTriggerStay(Collider trig)
    {
        var damageable = trig.GetComponent<IDamageable>();
        int _counter = 1;
        if (damageable != null && _counter ==1)
        {
            m_Animator.SetTrigger("Attack");
            _particles.Play();
            damageable.SubtractLifeFunc(_damage);
            stop = 0;
            _counter--;
            StartCoroutine(WaitForRestart(4));
            
        }
    }

    IEnumerator WaitForRestart(float time)
    {
        yield return new WaitForSeconds(time);
        Debug.Log("beeRestart");
        stop = 1;
        StartingPosition();
    }

    void StartingPosition()
    {
        m_Animator.SetBool("Moving", true);
        gameObject.transform.forward += honey.transform.position + new Vector3(0, 0.4f, 0.7f);
    }
}
