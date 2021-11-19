using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsContoller : MonoBehaviour
{
    public static PointsContoller instance;
    
    public static int totalScore;
    public static string playerName;
    
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

    private void Start()
    {
        SaveGame.instance.OnLoadGameData += LoadGameData;
        SaveGame.instance.gameData.collectPointInt = totalScore;
    }

    public void LoadGameData(GameData data)
    {
    }

    public static void SumScore(int score)
    {
        totalScore += score;
       
        //SaveGame.instance.gameData.collectPointInt = totalScore;

    }
    

    
    
}
