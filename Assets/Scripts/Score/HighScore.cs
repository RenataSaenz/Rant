using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
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
    Dictionary<string, int> playersScores = new Dictionary<string, int>();
    private IOrderedEnumerable<KeyValuePair<string, int>> sortedDict;

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
        for (int i = 0; i <= 100; i++)
        {
            
            Debug.Log("Game loaded: "+ i.ToString());
            SaveGame.instance.numberGame = i;
            
            var check = SaveGame.instance.CheckData();
            
            if (!check) break;
            
            int n = i +1;
            SaveGame.instance.Load();
            if (PointsContoller.playerName == "")
            { 
                Debug.Log("Player does not have a name, number used for player is: " + n);
                PointsContoller.playerName = "player" + n;
           }
            Debug.Log("Total score of " + PointsContoller.playerName + " is "+ PointsContoller.totalScore.ToString()); 
            playersScores.Add(PointsContoller.playerName, PointsContoller.totalScore);
            
            if (playersScores.Count == 2)break;
        }
        sortedDict = from entry in playersScores orderby entry.Value descending select entry;
    }
}

