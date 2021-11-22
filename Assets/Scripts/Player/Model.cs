using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Model 
{ 
    public float maxLife;
    public float minLife;
    public float life;
    public float forwardSpeed;
    public float swipeSpeed;
    public Transform myTransform;
    public ParticleSystem damageParticles;
    
    
    Rigidbody _rb;
    public Model(float sp, float swipeS, float maxL, float minL, Transform myT, Ant ant, ParticleSystem particles)
    {
        maxLife = maxL;
        minLife = minL;
        swipeSpeed = swipeS;
        life = maxLife;
        forwardSpeed = sp;
        myTransform = myT;
        damageParticles = particles;
    }
   
}
