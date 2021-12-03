using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : IFactory<Bullet>
{
    public Bullet Create(Bullet bulletPrefab)
    {
        var bullet = Object.Instantiate(bulletPrefab);
        return bullet;
    }
   
   /*public Bullet Build()
   {
       var bullet = BulletSpawner.instance.bullet.GetComponent<Bullet>();

       return Object.Instantiate(bullet);
   }*/
}
