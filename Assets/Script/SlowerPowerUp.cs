using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowerPowerUp : MonoBehaviour, ICollectable
{
    [SerializeField]
    private ParticleSystem _slowParticles;

    public void Collect()
    {
        SoundManager.instance.Play(SoundManager.Types.PowerUp);
        Instantiate(_slowParticles, transform.position, transform.rotation);
        this.gameObject.SetActive(false);
    }
}
