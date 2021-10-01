using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FasterPowerUp : MonoBehaviour, ICollectable
{
    [SerializeField]
    private ParticleSystem _fastParticles;
    [SerializeField]
    private float _velocity;

    public void Collect()
    {
        SoundManager.instance.Play(SoundManager.Types.PowerUp);
        Instantiate(_fastParticles, transform.position, transform.rotation);
        EventManager.Trigger("FastPowerUp", _velocity);
        this.gameObject.SetActive(false);
    }
}
