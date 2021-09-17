using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{

    float _lerpSpeed;
    float _lifes;
    float _maxLife;
    public Image lifeBar;
    //public Text lifeText;
    LifeManager _lifeManager;

    public void Awake()
    {
        _lifeManager = GameObject.Find("LifeManager").GetComponent<LifeManager>();
    }

 
    public void Update()
    {
        _maxLife = _lifeManager.maxLife;
        _lifes = _lifeManager.life;
        MoodBarFiller();
        //ColorChanger();
        //Text();
    }
    public void MoodBarFiller()
    {
        _lerpSpeed = 3f * Time.deltaTime;
        lifeBar.fillAmount = Mathf.Lerp(lifeBar.fillAmount, _lifes / _maxLife, _lerpSpeed);
    }
    public void ColorChanger()
    {
        Color moodColor = Color.Lerp(Color.black, Color.red, (_lifes / _maxLife));
        lifeBar.color = moodColor;
    }
    public void Text()
    {
       // lifeText.text = "Life: " + _lifes + "%";
    }
}
