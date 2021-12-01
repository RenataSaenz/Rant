using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{ 
    [Header("Player Atrributes")]
    public float maxLife;
    public float minLife;
    public float forwardSpeed;
    public float swipeSpeed;
    public ParticleSystem damageParticles;
    public Vector3 InitialPosition;
    public float life;
    Rigidbody _rb;
    Transform transform;
    public List<Vector3> _swipePoints = new List<Vector3>();
    public List<Weapon> weapons;
    
    

    [Header("Scripts")]
    public ManagerUI managerUI;
    public FasterPowerUp fasterPowerUp;
    void Awake()
    {
        transform = GetComponent<Transform>();
        _rb = GetComponent<Rigidbody>();
        life = maxLife;
        
    }
   
}
