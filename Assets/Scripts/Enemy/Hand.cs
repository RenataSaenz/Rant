using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Hand : MonoBehaviour
{
    private HandManager manager;
    [SerializeField]
    private float speed = 5f;
    float minDist = 0;
    private float _initialPosZ;
    //[SerializeField]
    //private int _handSize = 30;
    Action _ArtificialHand;
    
    void OnCollisionEnter(Collision col)
    {
        var damageable = col.collider.GetComponent<IDamageable>();
        if (damageable != null)
        {
            damageable.SubtractLifeFunc(FlyweightPointer.Enemy.damage);
        }

    }

    private void Awake()
    {
        transform.position = Vector3.zero;
        _ArtificialHand = NewHand;
    }

    private void Update()
    {
        if (transform.position.z <= minDist)
        {
            _ArtificialHand();
        }
    }

    void NewHand()
    {
        manager.NewHand();
        _ArtificialHand = ReturnHand;
    }

    void ReturnHand()
    {
        manager.ReturnHand(this);
        minDist = 0;
    }

    public static void TurnOff(Hand floor)
    {
        floor.gameObject.SetActive(false);
    }

    public static void TurnOn(Hand floor)
    {
        floor.gameObject.SetActive(true);
    }
    public void  InitializeHand(HandManager m, float pos)
    {
        _initialPosZ = pos;
        manager = m;
        transform.position = new Vector3(0, 0, pos);
        _ArtificialHand = NewHand;
        //minDist = 0
    }
    public void NextInPatronHand(HandManager m, float pos)
    {
        InitializeHand(m, pos);
    }
}
