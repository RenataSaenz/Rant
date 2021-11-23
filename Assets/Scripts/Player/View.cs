using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class View : MonoBehaviour, IObservable
{
    List<IObserver> _allObservers = new List<IObserver>();
    private ParticleSystem _damageParticles;
    private Transform _transform;
    
    private PlayerModel _playerModel;
    
    private void Awake()
    {
        _playerModel = GetComponent<PlayerModel>();
        _damageParticles = _playerModel.damageParticles;
        _transform = _playerModel.transform;
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

    public void NotifyToObservers(float value, float maxValue)
    {
        for (int i = 0; i < _allObservers.Count; i++)
            _allObservers[i].Notify(value, maxValue);
    }

}
