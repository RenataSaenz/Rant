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

    void Update()
    {
        transform.position += Vector3.forward * speed * Time.deltaTime;
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

        /*if (other.gameObject.layer == 12)
            TakeDamage();*/
    }
}
