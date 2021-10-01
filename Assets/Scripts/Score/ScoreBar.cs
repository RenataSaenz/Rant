using UnityEngine;
using UnityEngine.UI;


public class ScoreBar : MonoBehaviour
{/*

    float _lerpSpeed;
    float _score;
    float _maxScore;
    public Image scoreBar;
    public Text scoreText;
    ScoreManager _lifeManager;

    public void Awake()
    {
        _lifeManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }
    public void Update()
    {
        _maxScore = _lifeManager.maxLife;
        _score = _lifeManager.life;
        MoodBarFiller();
        ColorChanger();
        Text();
    }
    public void MoodBarFiller()
    {
        _lerpSpeed = 3f * Time.deltaTime;
        scoreBar.fillAmount = Mathf.Lerp(scoreBar.fillAmount, _score / _maxScore, _lerpSpeed);
    }
    public void ColorChanger()
    {
        Color moodColor = Color.Lerp(Color.black, Color.white, (_score / _maxScore));
        scoreBar.color = moodColor;
    }
    public void Text()
    {
        scoreText.text = "Score: " + _score + "%";
    }*/
}
