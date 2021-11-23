using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FasterPowerUp : MonoBehaviour 
{ 
    List<IObserver> _allObservers = new List<IObserver>();
    
    [SerializeField]
    private ParticleSystem _fastParticles;
    [SerializeField]
    private float _maxDistanceUnits;

  /*  public void Collect()
    {
        SoundManager.instance.Play(SoundManager.Types.PowerUp);
        Instantiate(_fastParticles, transform.position, transform.rotation);
        EventManager.Trigger("FastPowerUp", _maxDistanceUnits);
        this.gameObject.SetActive(false);
        
    }*/
  
  private void OnTriggerEnter(Collider other)
  {
      var obj = other.gameObject.GetComponent<IPowerUp>();

      if (obj != null) obj.ChangePower(_maxDistanceUnits);
      
      SoundManager.instance.Play(SoundManager.Types.PowerUp);
      Instantiate(_fastParticles, transform.position, transform.rotation);
      this.gameObject.SetActive(false);
  }
  
}
