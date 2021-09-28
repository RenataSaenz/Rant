﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FasterPowerUp : MonoBehaviour, ICollectable
{
    [SerializeField]
    private ParticleSystem _fastParticles;

    public void Collect()
    {
        SoundManager.instance.Play(SoundManager.Types.PowerUp);
        Instantiate(_fastParticles, transform.position, transform.rotation);
        this.gameObject.SetActive(false);
    }
}