using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Ad : MonoBehaviour
{
    [FormerlySerializedAs("AdObject")] [SerializeField] private Image _adObject;
    [SerializeField] private int _points = 50;

    private void Start()
    {
        SoundManager.instance.Play(SoundManager.Types.Victory);
    }


    public void AddPointsEvent()
    {
            PointsContoller.SumScore(_points);
    }

    public void DisableEvent()
    {
        _adObject.enabled= false;
    }
}
