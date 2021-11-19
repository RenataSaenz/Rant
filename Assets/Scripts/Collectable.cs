using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collectable : MonoBehaviour, ICollectable
{
    public int collectableValue = 1;
    
    public void Collect()
    {
        SoundManager.instance.Play(SoundManager.Types.Collect);
        PointsContoller.SumScore(collectableValue);
        gameObject.SetActive(false);
    }
}
