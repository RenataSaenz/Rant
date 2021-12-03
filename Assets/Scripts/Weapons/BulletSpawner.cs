using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public static BulletSpawner instance;
    public Bullet bullet;
    public Pool<Bullet> pool;
    public BulletBuilder bulletBuilder;
    public Transform _firstBullet;

    void Awake()
    {
        instance = this;
        bulletBuilder = new BulletBuilder();
    }
    private void Start()
    {
        bulletBuilder.ShootPoint(_firstBullet);
        pool = new Pool<Bullet>(bulletBuilder.Build, Bullet.TurnOff, Bullet.TurnOn,  1);
    }

    public void Spawn()
    {
        bulletBuilder.Configure();
    }

    public void ReturnBullet(Bullet bullet)
    {
        pool.Return(bullet);
    }

}