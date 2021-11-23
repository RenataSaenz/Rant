using UnityEngine;
using UnityEngine.UI;
using System;

public class LifeBar : MonoBehaviour, IObserver
{
    public Image lifeBar;
    IObservable _playerToCopy;
    public View _view;
    private void Start()
    {
        _playerToCopy = _view;
        _playerToCopy.Subscribe(this);
    }

    void BarUpdate(float _life, float _maxLife)
    {
        lifeBar.fillAmount = (_life / _maxLife);
    }

    public void Notify(float value, float maxValue)
    {
            BarUpdate(value, maxValue);
    }

}
