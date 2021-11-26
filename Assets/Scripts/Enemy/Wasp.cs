using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wasp : MonoBehaviour
{
    GameObject target;
    public Transform shootPoint;
    
    public float timeToShoot;
    private float _restartTimeToShoot;

    private void Awake()
    {
        _restartTimeToShoot = timeToShoot;
    }

    void FixedUpdate()
    {
        if (target != null)
            transform.LookAt(target.transform);
        
    }

    void Shoot()
    {
        timeToShoot -= Time.deltaTime;
        if (timeToShoot < 0)
        {
            Debug.Log("Shoot");
            BulletSpawner.instance.Spawn(shootPoint);
            timeToShoot = _restartTimeToShoot;
        }
        
    }

    private void OnTriggerStay(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            target = other.gameObject;
            Shoot();
        }
    }


}