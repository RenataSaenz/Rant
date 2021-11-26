using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public static BulletSpawner instance;
    public Bullet bullet;
    public Pool<Bullet> pool;

    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        pool = new Pool<Bullet>(Create, Bullet.TurnOff, Bullet.TurnOn,  1);
    }

    public Bullet Create()
    {
        BulletFactory _factory = new BulletFactory();
        return _factory.Create(bullet);
    }

    public void Spawn(Transform shootPoint)
    {
        pool.Get().Position(shootPoint);
    }

    public void ReturnBullet(Bullet bullet)
    {
        pool.Return(bullet);
    }

}