using UnityEngine;
using UnityEngine.UI;
using System;

public class LifeBar : MonoBehaviour, IObserver
{
    float _lerpSpeed;
    public Image lifeBar;
    IObservable _playerToCopy;
    public Ant ant;
    float _life;
    float _maxLife;

    private void Start()
    {
        _playerToCopy = ant;
        _playerToCopy.Subscribe(this);
        _maxLife = ant.maxLife;
        _life = _maxLife;
    }

    void Update()
    {
        BarUpdate();
    }
    public void LifeBarFiller(float life)
    {
        _life = life;
    }

    void BarUpdate()
    {
        _lerpSpeed = 3f * Time.deltaTime;
        lifeBar.fillAmount = Mathf.Lerp(lifeBar.fillAmount, _life / _maxLife, _lerpSpeed);
    }

    public void Notify(string action, float life)
    {
        if (action == "AddLife")
        {
            LifeBarFiller(life);
            Debug.Log("AddLife");
        }else if (action == "SubtractLife")
        {
            LifeBarFiller(life);
            Debug.Log("SubLife");
        }
            
    }
}
