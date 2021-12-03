using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float _speed;
    float _maxTime;
    float _actualTime;
    public float _damage;
    Rigidbody _rb;
    public ParticleSystem _explosionParticles;

    public Mesh _mesh;
    public Material _material;
    private Transform _shootPoint;

    private MeshFilter _bulletMesh;
    private Renderer _bulletRender;
    private LayerMask _target;

    //public static BulletBuilder bulletBuilder;

    private void Awake()
    {
        //bulletBuilder = new BulletBuilder();
        _rb = gameObject.GetComponent<Rigidbody>();
        _maxTime = 0.8f;
        
        _bulletMesh = gameObject.GetComponent<MeshFilter>();
        _bulletRender = gameObject.GetComponent<Renderer>();

    }

    public void Attributes(float speed, float damage, ParticleSystem explosionParticles, Mesh mesh, Material material, Transform shootPoint, LayerMask layerMask)
    {
        _shootPoint = shootPoint;
        _speed = speed;
        _damage = damage;
        _explosionParticles = explosionParticles;
        _mesh = mesh;
        _material = material;
        _target = layerMask;
        
        Set();
    }

    private void FixedUpdate()
    {
        _rb.velocity = transform.forward * _speed;
        
        //transform.localPosition.Translate(Vector3.forward * speed  * Time.deltaTime);
        
        _actualTime += Time.deltaTime;
        if (_actualTime > _maxTime)
        {
            _actualTime -= _maxTime;
            if (_explosionParticles!= null) Instantiate(_explosionParticles, transform.position, transform.rotation);
            BulletSpawner.instance.ReturnBullet(this);
        }
    }
    public void Set()
    {
        transform.position = _shootPoint.position;
        transform.rotation = _shootPoint.rotation;
        _bulletMesh.mesh = _mesh;
        _bulletRender.material = _material;
    }
      
    public static void TurnOn(Bullet b)
    {
        b.gameObject.SetActive(true);
    }
      
    public static void TurnOff(Bullet b)
    {
        b.gameObject.SetActive(false);
    } 
      
    void OnTriggerEnter(Collider other)
    {
        var damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.SubtractLifeFunc(_damage);
            //damageable.SubtractLifeFunc(FlyweightPointer.Enemy.damage);
        }
        if (_explosionParticles!= null) Instantiate(_explosionParticles, transform.position, transform.rotation);
        BulletSpawner.instance.ReturnBullet(this);
    }
}