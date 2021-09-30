using UnityEngine;
using UnityEngine.UI;
using System;

public class LifeBar : MonoBehaviour, IObserver
{
    float _lerpSpeed;
    public Image lifeBar;
    IObservable _playerToCopy;
    public Ant ant;
    
    private void Start()
    {
        _playerToCopy = ant;
        _playerToCopy.Subscribe(this);
    }
    
    void BarUpdate(float _life, float _maxLife)
    {
        _lerpSpeed = 3f * Time.deltaTime;
        lifeBar.fillAmount = Mathf.Lerp(lifeBar.fillAmount, _life / _maxLife, _lerpSpeed);
    }

    public void Notify(string action, float life, float maxLife)
    {
        if (action == "StartLife")
        {
            BarUpdate(life, maxLife);
            Debug.Log("StartLife");
        }
        if (action == "AddLife")
        {
            BarUpdate(life, maxLife);
            Debug.Log("AddLife");
        }
        else if (action == "SubtractLife")
        {
            BarUpdate(life, maxLife);
            Debug.Log("SubLife");
        }
    }

}
