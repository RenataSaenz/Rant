using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : IObservable
{
    List<IObserver> _allObservers = new List<IObserver>();
    private ParticleSystem _damageParticles;
    private Transform _transform;
    public View(Model model)
    {
        _damageParticles = model.damageParticles;
        _transform = model.myTransform;
    }
    public void UpdateHudLife(float life, float maxLife)
    {
        NotifyToObservers(life, maxLife);
    }
    public void TakeDamage()
    {
        GameObject.Instantiate(_damageParticles, _transform.position, _transform.rotation);
    }
    public void Subscribe(IObserver obs)
    {
        if (!_allObservers.Contains(obs))
            _allObservers.Add(obs);
    }

    public void Unsubscribe(IObserver obs)
    {
        if (_allObservers.Contains(obs))
            _allObservers.Remove(obs);
    }

    public void NotifyToObservers(float life, float maxLife)
    {
        for (int i = 0; i < _allObservers.Count; i++)
            _allObservers[i].Notify(life, maxLife);
    }

}
