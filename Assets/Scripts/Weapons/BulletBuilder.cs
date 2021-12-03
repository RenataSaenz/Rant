using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBuilder 
{
    float _speed;
    float _damage;
    ParticleSystem _explosionParticles;
    Mesh _mesh;
    Material _material;
    private Transform _shootPoint;
    private LayerMask _layerMask;

    public void Speed(float speed)
    {
        _speed = speed;
    }
    public void Damage(float damage)
    {
        _damage = damage;
    }
    public void Particles(ParticleSystem explosionParticles)
    {
        _explosionParticles = explosionParticles;
    }
    public void Mesh(Mesh mesh)
    {
        _mesh = mesh;
    }
    public void Material(Material material)
    {
        _material = material;
    }
    public void ShootPoint(Transform shootPoint)
    {
        _shootPoint = shootPoint;
    }
    public void Target(LayerMask layerMask)
    {
        _layerMask = layerMask;
    }

    public void Configure()
    {
        BulletSpawner.instance.pool.Get().Attributes(_speed, _damage, _explosionParticles, _mesh, _material, _shootPoint, _layerMask);
    }

    public Bullet Build()
    {
        BulletFactory factory = new BulletFactory();
        Bullet bullet = factory.Create(BulletSpawner.instance.bullet);
        bullet.Attributes(_speed, _damage, _explosionParticles, _mesh, _material, _shootPoint, _layerMask);
        
        
        return bullet;
    }

}
