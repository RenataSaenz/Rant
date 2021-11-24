using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    public static HighScore instance;

    public GameObject highScoreCanvas;

    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI secondHighScore;
    public TextMeshProUGUI thirdHighScore;
    public TextMeshProUGUI nameScore;
    public TextMeshProUGUI nameHighScore;
    public TextMeshProUGUI nameSecondHighScore;
    public TextMeshProUGUI nameThirdHighScore;
    private int score0;
    private int score1;
    private int score2;
    private List<UserDetails> _playersData = new List<UserDetails>();
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        highScoreCanvas.SetActive(false);
    }

    public void LoadScores()
    {
        highScoreCanvas.SetActive(true);
        SaveGame.instance.Load();
        score.text = PointsContoller.totalScore.ToString();
        nameScore.text = PointsContoller.playerName + ":";
        SetScores();
    }

    void SetScores()
    {
        SaveGame.instance.Load();
        
        _playersData =  SaveGame.instance.scoreListData.list.OrderByDescending(i => i.score).ToList();
        foreach( var x in _playersData) {
            Debug.Log( x.name + ": " + x.score.ToString());
        }

        GetHighestScores();
    }
    
    void GetHighestScores()
    {

        highScore.text = _playersData[0].score.ToString();
        secondHighScore.text = _playersData[1].score.ToString();
        thirdHighScore.text = _playersData[2].score.ToString();
        
        nameHighScore.text =_playersData[0].name;
        nameSecondHighScore.text= _playersData[1].name;
        nameThirdHighScore.text = _playersData[2].name;
    }
}

