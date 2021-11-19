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
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI secondHighScore;
    public TextMeshProUGUI thirdHighScore;
    private int score0;
    private int score1;
    private int score2;
    Dictionary<int, string> playersScores = new Dictionary<int, string>();
    private IOrderedEnumerable<KeyValuePair<int, string>> sortedDict;
    
    void Start()
    {  
        SaveGame.instance.Load();
        score.text = PointsContoller.totalScore.ToString();
        SetScores();
    }

    void SetScores()
    {
        var gamesSaved = Enumerable.Range(0,2);
        foreach (var i in gamesSaved)
        {
            SaveGame.instance.numberGame = i;
            var check = SaveGame.instance.CheckData();
            if (check)
            {
                SaveGame.instance.Load();
                playersScores.Add(PointsContoller.totalScore, PointsContoller.playerName);
            }
        } 
        sortedDict = from entry in playersScores orderby entry.Value descending select entry;
    }
    
}
