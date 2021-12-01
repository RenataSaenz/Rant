using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform shootPoint;
    [SerializeField]protected float _fireRate;
    protected float _restartTimeToShoot;

    public void Awake()
    {
        Debug.Log("AWAKEwAPOEN");
        _restartTimeToShoot = _fireRate;
        _fireRate = 0;
        gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        _fireRate -= Time.deltaTime;
        
    }

    public void TurnOff()
    {
        gameObject.SetActive(false);
    }
    public void TurnOn()
    {
        gameObject.SetActive(true);
    }

    public virtual void Shoot()
    {
        
        Debug.Log("weapon.shoot");
        if (_fireRate < 0)
        {
            BulletSpawner.instance.Spawn(shootPoint);
            _fireRate = _restartTimeToShoot;
        }
    }
}
