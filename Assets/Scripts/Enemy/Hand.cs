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
    private GameObject parent;
    private Floor floor;
    
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
    }

    private void Update()
    {
        if (!floor)
        {
            _ArtificialHand = ReturnHand;
        }
    }

    void NewHand()
    {
        manager.NewHand();
    }

    void ReturnHand()
    {
       manager.ReturnHand(this);
    }

    public static void TurnOff(Hand floor)
    {
        floor.gameObject.SetActive(false);
    }

    public static void TurnOn(Hand floor)
    {
        floor.gameObject.SetActive(true);
    }
    public void  InitializeHand(HandManager m, Vector3 pos)
    {
        parent = m.floorParent;
        floor = parent.GetComponent<Floor>();
        transform.SetParent(parent.transform, false);
        manager = m;
        transform.localPosition = pos;
        _ArtificialHand = NewHand;
        
        //Animation Play
        
        



    }
    public void NextInPatronHand(HandManager m, Vector3 pos, float z)
    {
        var totalPos = new Vector3();
        totalPos = new Vector3(pos.x, pos.y, pos.z + z);
        InitializeHand(m, totalPos);
    }
}
