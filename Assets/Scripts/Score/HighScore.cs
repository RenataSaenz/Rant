using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    //public static HighScore Instance;

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
        /*if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }*/

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
        //SaveGame.Instance.Load();
        
        _playersData =  SaveGame.instance.recentPlayersData.list.OrderByDescending(i => i.score).ToList();
       /* foreach( var x in _playersData) {
            Debug.Log( x.name + ": " + x.score.ToString());
        }*/
       
       GetHighestScores();
    }
    
    void GetHighestScores()
    {
        if (_playersData[0] != null)
        {
            highScore.text = _playersData[0].score.ToString();
            nameHighScore.text =_playersData[0].name;
        }
        if (_playersData[1] != null)
        {
            secondHighScore.text = _playersData[1].score.ToString();
            nameSecondHighScore.text= _playersData[1].name;
        }
        else return;
        if (_playersData[2] != null)
        {
            thirdHighScore.text = _playersData[2].score.ToString();
            nameThirdHighScore.text = _playersData[2].name;
        }
    }
}

