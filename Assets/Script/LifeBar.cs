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
    public void MoodBarFiller(float life, float maxLife)
    {
        life = ant.life;
        _lerpSpeed = 3f * Time.deltaTime;
        lifeBar.fillAmount = Mathf.Lerp(lifeBar.fillAmount, life / maxLife, _lerpSpeed);
        ColorChanger(life, maxLife);
    }
    public void ColorChanger(float life, float maxLife)
    {
        life = ant.life;
        Color moodColor = Color.Lerp(Color.black, Color.red, (life / maxLife));
        lifeBar.color = moodColor;
    }

    public void Notify(string action)
    {
        if (action == "AddLife")
            
            Debug.Log("AddLife");
        else if (action == "SubtractLife")
            Debug.Log("SubtractLife");
    }
}
