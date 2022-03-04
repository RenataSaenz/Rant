using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    //public static HighScore Instance;

    public GameObject highScoreCanvas;

    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI secondHighScore;
    public TextMeshProUGUI thirdHighScore;
    public Text nameScore;
    public TextMeshProUGUI nameHighScore;
    public TextMeshProUGUI nameSecondHighScore;
    public TextMeshProUGUI nameThirdHighScore;
    private int score0;
    private int score1;
    private int score2;
    private List<UserDetails> _playersData = new List<UserDetails>();

    private void Awake()
    {
        highScoreCanvas.SetActive(false);
    }


    public void LoadScores()
    {
        highScoreCanvas.SetActive(true);
        //StartCoroutine(WaitForLoadScene(5));
        SaveGame.instance.Load();
        
        score.text = PointsContoller.totalScore.ToString();
         nameScore.text = PointsContoller.playerName + ":";
         SetScores();
    }

    void SetScores()
    {
        _playersData =  SaveGame.instance.recentPlayersData.list.OrderByDescending(i => i.score).ToList();
       /* foreach( var x in _playersData) {
            Debug.Log( x.name + ": " + x.score.ToString());
        }*/
       
       GetHighestScores();
    }
    
    void GetHighestScores()
    {
            highScore.text = _playersData[0].score.ToString();
            nameHighScore.text =_playersData[0].name;
            
        if (_playersData.Count > 1)
        {
            secondHighScore.text = _playersData[1].score.ToString();
            nameSecondHighScore.text= _playersData[1].name;
        }
        if (_playersData.Count > 2)
        {
            thirdHighScore.text = _playersData[2].score.ToString();
            nameThirdHighScore.text = _playersData[2].name;
        }
    }
    
    IEnumerator WaitForLoadScene(float time)
    {
        yield return new WaitForSeconds(time);
        SaveGame.instance.Load();
        score.text = PointsContoller.totalScore.ToString();
        nameScore.text = PointsContoller.playerName + ":";
        SetScores();
    }
}



