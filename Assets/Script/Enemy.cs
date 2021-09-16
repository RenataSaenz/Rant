using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Transform _transform;
    [SerializeField]
    protected float _health = 1f;
    [SerializeField]
    protected GameObject _sound;
    [SerializeField]
    protected ParticleSystem _particleSystem;
    public int damage;

    public float range = 1f;


    public void Awake()
    {
        if (_sound != null)
            _sound.SetActive(false);
    }

    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit, range))
        {
            Ant ant = hit.transform.GetComponent<Ant>();
            if (ant != null)
            {
                Debug.Log("touch");
                EventManager.Trigger("SubtractLife", damage);
            }
        }
    }
    public void TakeDamage(float amount)
    {
        _health -= amount;
        if (_health <= 0f)
        {
            Die();
        }
    }

    virtual public void Die()
    {
        Instantiate(_particleSystem, transform.position, transform.rotation);
       // Accessor.EnemiesDead(1);
        Destroy(gameObject);
    }

    virtual public void Move()
    {
        //transform.LookAt(_target);

    }

    virtual public void Action()
    {
        if (_sound != null)
            _sound.SetActive(true);
    }
}
