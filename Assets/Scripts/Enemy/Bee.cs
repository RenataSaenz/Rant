using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bee : MonoBehaviour
{
    public Animator m_Animator;

    public PlayerModel target;

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
    //[SerializeField]
   // private float startMaxSpeed;
    bool chase = false;

    float rayMaxDistance = 10;
    bool isHit;
    public Collider beeCollider;
    RaycastHit hit;

    public Transform honey;
    private float stop = 1;

    public float range = 1f;

    int layer_mask;

    private void Start()
    {
        StartingPosition();
       layer_mask = LayerMask.GetMask("Player");
       chase = false;
       
    }

    private void Update()
    {   
        if (chase ==false)
            HoneyRound();

        RaycastHit hit;
        isHit = Physics.BoxCast(beeCollider.bounds.center, new Vector3(5, 2, 1), transform.forward, out hit, Quaternion.identity, layer_mask);
        if (isHit)
        {
            chase = true;
           // Debug.Log("seek");
            ApplyForce(Seek());
            transform.position += _velocity * Time.deltaTime * stop;
            transform.forward = _velocity;
        }
        
    }
    void OnTriggerStay(Collider trig)
    {

        //Debug.Log("hitted");
        var damageable = trig.transform.gameObject.GetComponent<IDamageable>();
        int _counter = 1;
        if (damageable != null && _counter == 1)
        {
            chase = true;
            m_Animator.SetTrigger("Attack");
            _particles.Play();
            damageable.SubtractLifeFunc(_damage);
            stop = 0;
            chase = false;
            _counter--;
            StartCoroutine(WaitForRestart(2));
        }


    }
    Vector3 Seek()
    {
        m_Animator.SetBool("Moving", true);

        Vector3 desired = ((Component) target).transform.position - transform.position;


        desired.Normalize();  //si queremos que vaya mas rapido cuanto mas lejos y no constante, borrar el normalizado.
        desired *= maxSpeed;

        Vector3 steering = desired - _velocity;
        steering = Vector3.ClampMagnitude(steering, maxForce);  //para que gire constantemente a la fuerza que le queremos dar

        //ApplyForce(steering);
        return steering;
    }

    void HoneyRound()
    {
        m_Animator.SetBool("Moving", true);
        Vector3 honeyVec = honey.transform.position;

        transform.RotateAround(honeyVec, Vector3.up, 40 * Time.deltaTime * stop);
    }

    void ApplyForce(Vector3 force)
    {
        _velocity += force;

        _velocity = Vector3.ClampMagnitude(_velocity, maxSpeed);
    }

    IEnumerator WaitForRestart(float time)
    {
        yield return new WaitForSeconds(time);
        //Debug.Log("beeRestart");
        stop = 1;
        StartingPosition();
    }

    void StartingPosition()
    {
        //Debug.Log("StartingPosition");
        m_Animator.SetBool("Moving", true);
        gameObject.transform.position = honey.transform.position + new Vector3(0, 0.4f, 0.7f);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        //Check if there has been a hit yet
        if (isHit)
        {
            //Draw a Ray forward from GameObject toward the hit
            Gizmos.DrawRay(transform.position, transform.forward * hit.distance);
            //Draw a cube that extends to where the hit exists
            Gizmos.DrawWireCube(transform.position + transform.forward * hit.distance, new Vector3(5, 2, 1));
        }
        //If there hasn't been a hit yet, draw the ray at the maximum distance
        else
        {
            //Draw a Ray forward from GameObject toward the maximum distance
            Gizmos.DrawRay(transform.position, transform.forward * rayMaxDistance);
            //Draw a cube at the maximum distance
            Gizmos.DrawWireCube(transform.position + transform.forward * rayMaxDistance, new Vector3(5, 2, 1));
        }
    }
}
