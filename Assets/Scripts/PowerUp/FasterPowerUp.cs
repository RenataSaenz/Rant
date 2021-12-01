using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FasterPowerUp : MonoBehaviour 
{
    [SerializeField]
    private ParticleSystem _fastParticles;
    [SerializeField]
    private float _maxDistanceUnits;
    
    private void OnTriggerEnter(Collider other)
  {
      var obj = other.gameObject.GetComponent<IPowerUp>();

      if (obj != null) obj.ChangePower(_maxDistanceUnits);
      
      SoundManager.instance.Play(SoundManager.Types.PowerUp);
      Instantiate(_fastParticles, transform.position, transform.rotation);
      this.gameObject.SetActive(false);
  }
  
}
