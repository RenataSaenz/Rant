using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
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
        PointsContoller.totalScore = 0;
        //GameData ld = new GameData();
        
       // Debug.Log(ld.ToJson());
       
    } 
  
   
   //SaveGame.instance.Load();  //recargar partida
   
}
