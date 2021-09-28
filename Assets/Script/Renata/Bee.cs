using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    public Animator m_Animator;

    public GameObject target;

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

    float m_MaxDistance = 6;
    bool m_HitDetect;
    public Collider m_Collider;
    RaycastHit m_Hit;

    private void Update()
    {
       m_HitDetect = Physics.BoxCast(m_Collider.bounds.center, transform.localScale, transform.forward, out m_Hit, transform.rotation, m_MaxDistance);


        if (m_HitDetect)
        {
            Seek();

            transform.position += _velocity * Time.deltaTime;
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

    void ApplyForce(Vector3 force)
    {
        _velocity += force;
    }

    void OnTriggerStay(Collider trig)
    {
        var damageable = trig.GetComponent<IDamageable>();

        if (damageable != null)
        {
            
            m_Animator.SetTrigger("Attack");
            _particles.Play();
            damageable.SubtractLifeFunc(_damage);
            StartCoroutine(WaitForNextAttack(_nextAttack));
        }
    }
    IEnumerator WaitForNextAttack(float time)
    {
        time = 5;
        yield return new WaitForSeconds(time);
        Debug.Log("counter");
        _counter = 1;
    }
    /*
    void OnDrawGizmosSelected()
    {
        // Draw a semitransparent blue cube at the transforms position
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawCube(transform.position, new Vector3(10, 1, 10));
    }*/
}
