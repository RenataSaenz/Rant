using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ant : MonoBehaviour, IDamageable
{
    public float speed;
    public bool isDead;
    public int health = 1;
    private int currentHealth;
    public float dieTimer;

    public ManagerUI managerUI;

    Control _control;

    private Rigidbody _rb;

    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _control = new Control(this);
        //playerAudio = GetComponent<PlayerAudio>();
        currentHealth = health;
    }

    void Update()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
        _control.OnUpdate();
    }

    public void TakeDamage()
    {
        currentHealth--;

        if (currentHealth <= 0)
        {
            speed = 0;
            isDead = true;
            //animator.SetTrigger(deathTriggerName);
            //playerAudio.deathSound.Play();
            EventManager.Trigger("GameOver", dieTimer);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var obj = other.gameObject.GetComponent<ICollectable>();

        if (isDead == false & obj != null)
        {
            obj.Collect();
        }

        if (other.gameObject.layer == 8)
        {
            TakeDamage();
        } 
    }

}
