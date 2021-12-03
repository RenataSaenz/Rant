using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform shootPoint;
    [SerializeField]protected float _fireRate;
    protected float _restartTimeToShoot;
    //[SerializeField]protected Bullet _bullet;
    
    [Header("Bullet")]
    public float speed;
    [SerializeField]protected float _damage;
    [SerializeField]protected ParticleSystem _explosionParticles;
    [SerializeField]protected Mesh _mesh;
    [SerializeField]protected Material _material;
    [SerializeField]protected LayerMask _target;
    //BulletBuilder bulletBuilder;

    public void Awake()
    {
        //bulletBuilder = new BulletBuilder();
        _restartTimeToShoot = _fireRate;
        _fireRate = 0;
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
            BulletSpawner.instance.bulletBuilder.Damage(_damage);
            BulletSpawner.instance.bulletBuilder.Speed(speed);
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
            
            _fireRate = _restartTimeToShoot;
        }
    }
}
