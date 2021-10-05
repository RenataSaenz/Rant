using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public ManagerUI managerUI;
    private int score;
    public int totalScore;
    private void Awake()
    {
        if (instance == null)
        {
            Debug.Log("instanced");
            instance = this;
        }
        else
        {
            Debug.Log("destroyed");
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    public void ChangeScore(int collectableValue)
    {
        score += collectableValue;
        managerUI.ChangeScore(score);
    }
    public void TotalScore()
    {
        totalScore = score;
        managerUI.TotalPoints(totalScore);
    }

}
