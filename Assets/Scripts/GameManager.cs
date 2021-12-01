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
        //UserDetails ld = new UserDetails();
        
       // Debug.Log(ld.ToJson());
       
    } 
  
   
   //SaveGame.Instance.Load();  //recargar partida
   
}
