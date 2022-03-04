using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class AdReward : MonoBehaviour
{
    [FormerlySerializedAs("AdObject")] [SerializeField] private Image _adObject;
    [SerializeField] private int _points = 50;
    [SerializeField] private int _gems = 0;
    [SerializeField] private GameObject _adGameObject;

    private void Start()
    {
        SoundManager.instance.Play(SoundManager.Types.Victory);
    }
    public void AddPointsEvent()
    {
            PointsContoller.SumScore(_points);
            GemsContoller.SumGems(_gems);
    }
    public void DisableEvent()
    {
       if (_adObject !=null) _adObject.enabled= false;
       if (_adGameObject !=null)_adGameObject.SetActive(false);
    }
}
