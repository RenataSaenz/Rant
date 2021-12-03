﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HandManager : MonoBehaviour
{

    public Vector3 initialPos;

    public Hand prefab;

    public Pool<Hand> pool;

    //public int minHands;
    int _counter;
    
    public int handSize = 5;

    public float handsDistance;

    [SerializeField] private int numberOfHands;

    public GameObject floorParent;

    public float delay;
   // public float period = 0.1f;
    private float time = 0.0f;
    private int numHands;
    Action ActiveHand;

    private float ActualTime;

    private bool start;
    

    private void Awake()
    {
        start = false;
        //initialPosZ = prefab.transform.position.z;
        pool = new Pool<Hand>(Create, Hand.TurnOff, Hand.TurnOn, 1);
        ActiveHand = InstantiateHand;
        numHands = 0;
        ActualTime -= delay;
    }

    private void Start()
    {
        NewHand();
    }

    private void FixedUpdate()
    {
        if (start)
        {
            ActualTime += Time.deltaTime;
       
            if (numHands == 0)
            {
                NewHand();
                numHands += 1;
            }
            if (ActualTime > delay && 1 <= numHands &&  numHands <= (numberOfHands-1))
            {
                ActualTime = 0;
                pool.Get().NextInPatronHand(this, initialPos, (handSize * numHands) + handsDistance);
                numHands += 1;
            }

            if (numHands >= numberOfHands)
            {
                ActiveHand = delegate { };
                start = false;
            } 
        }
        

    }
    

    private void OnTriggerEnter( Collider other)
    {
        start = true;
    }


    public void NewHand()
    {
        ActiveHand();
    }

    public void ReturnHand (Hand hand)
    {
        pool.Return(hand);
    }

   void InstantiateHand()
    {
        pool.Get().InitializeHand(this, initialPos); //initialPosZ);
    }
    
    public Hand Create()
    {
        HandFactory _factory = new HandFactory();
        return _factory.Create(prefab);
    }

}