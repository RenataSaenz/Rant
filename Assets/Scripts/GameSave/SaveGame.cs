using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public static SaveGame instance;

    public int numberGame;
    public RecentPlayers recentPlayersData;
    public event Action<RecentPlayers> OnLoadGameData;
    string _fileName = "Game{0}Data.sav";   // private string _fileName = "Game{0}Data{1}";
    string _saveFilePath;
   
    
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

        _saveFilePath = Application.persistentDataPath + "/" + string.Format(_fileName, numberGame);
        Debug.Log(_saveFilePath);
    }

    private void Start()
    {
        Load();
    }

    public void Save()
    {
        try
        { 
            if (!File.Exists(_saveFilePath))
                File.Create(_saveFilePath);

            StreamWriter streamWriter = new StreamWriter(_saveFilePath, false);
            streamWriter.Write(recentPlayersData.ToJson());
            streamWriter.Close();
        }
        catch (Exception e)
        {
            Debug.LogError(e); 
        }
    }

    public void Load()
    {
        try
        {
            if (recentPlayersData == null)
                recentPlayersData = new RecentPlayers();
            if (File.Exists(_saveFilePath))
            {
                StreamReader streamReader = new StreamReader(_saveFilePath);
                //recentPlayersData = JsonUtility.FromJson<RecentPlayers>(streamReader.ReadToEnd());
                recentPlayersData = JsonUtility.FromJson<RecentPlayers>(streamReader.ReadToEnd());
                streamReader.Close();
                
                OnLoadGameData?.Invoke(recentPlayersData);
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
     
    }
    
}
