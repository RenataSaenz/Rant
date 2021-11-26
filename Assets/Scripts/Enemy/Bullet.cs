using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    private float _maxTime;
    private float _actualTime;
     Rigidbody _rb;

    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
        _maxTime = 0.5f;    
    }

    private void FixedUpdate()
    {
        _rb.velocity = transform.forward * speed;
        
        //transform.localPosition.Translate(Vector3.forward * speed  * Time.deltaTime);
        
        _actualTime += Time.deltaTime;
        if (_actualTime > _maxTime)
        {
            _actualTime -= _maxTime;
            Debug.Log("FIXED");
            BulletSpawner.instance.ReturnBullet(this);
        }
    }
    public void Position(Transform  shootPoint)
    {
        transform.position = shootPoint.position;
        transform.rotation = shootPoint.rotation;
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
        Debug.Log("cOLLISION WITH" + other);
        var damageable = other.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.SubtractLifeFunc(FlyweightPointer.Enemy.damage);
        }
        BulletSpawner.instance.ReturnBullet(this);
    }
}