using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private int _counter = 1;

    [SerializeField]
    private ParticleSystem _slowParticles;
    [SerializeField]
    private ParticleSystem _fastParticles;

    void OnTriggerEnter(Collider collision)
    {
        if (this.tag == "FasterPowerUp")
        {
            if (collision.tag == "Player" && _counter == 1)
            {   
                _counter--;
                SoundManager.instance.Play(SoundManager.Types.PowerUp);
                Instantiate(_fastParticles, transform.position, transform.rotation);
                this.gameObject.SetActive(false);
            }
        }
        else if (this.tag == "SlowerPowerUp")
        {
            if (collision.tag == "Player" && _counter == 1)
            {
                _counter--;
                SoundManager.instance.Play(SoundManager.Types.PowerUp);
                Instantiate(_slowParticles, transform.position, transform.rotation);
                this.gameObject.SetActive(false);
            }
        }
    }

    
}
