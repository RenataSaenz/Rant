using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collectable : MonoBehaviour, ICollectable
{
    public int collectableValue = 1;
    [SerializeField]
    private ParticleSystem _slowParticles;
    
    public void Collect()
    {
        SoundManager.instance.Play(SoundManager.Types.Collect);
        Instantiate(_slowParticles, transform.position, transform.rotation);
        PointsContoller.SumScore(collectableValue);
        gameObject.SetActive(false);
    }
}
