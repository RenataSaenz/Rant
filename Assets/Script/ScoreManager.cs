using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public ManagerUI managerUI;
    private int score;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
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

}
