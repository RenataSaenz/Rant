using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HandManager : MonoBehaviour
{
    public float initialPosZ = 0;

    public Hand prefab;

    public Pool<Hand> pool;

    //public int minHands;
    int _counter;
    
    public int handSize = 5;

    public float handsDistance;

    [SerializeField] private int numberOfHands;

    Action ActiveHand;
    

    private void Awake()
    {
        //initialPosZ = prefab.transform.position.z;
        pool = new Pool<Hand>(Create, Hand.TurnOff, Hand.TurnOn, 1);
        ActiveHand = InstantiateHand;
    }

    private void Start()
    {
        NewHand();
    }

    public void NewHand()
    {
        // pool.Get().InitialFloor(this, initialPosZ); 
        ActiveHand();
    }

    public void ReturnHand (Hand hand)
    {
        pool.Return(hand);
    }

    void InstantiateHand()
    {
        pool.Get().InitializeHand(this, initialPosZ);
        for (var c = 1; c <= numberOfHands; c++)
        {
            pool.Get().NextInPatronHand(this, initialPosZ + (handSize * c) + handsDistance);
            ActiveHand = delegate { };
        }
    }
    public Hand Create()
    {
        HandFactory _factory = new HandFactory();
        return _factory.Create(prefab);
    }
}
