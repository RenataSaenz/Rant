using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public static SaveGame instance;

    public int numberGame;
    public GameData gameData;
    public event Action<GameData> OnLoadGameData;
    string _fileName = "Game{0}Data.sav";   // private string _fileName = "Game{0}Data{1}"; //LevelAlgoDataOtraCosa
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

    public bool CheckData()
    {
        if (!File.Exists(_saveFilePath))return (false);
        else return (true);
    }

    public void Save()
    {
        try
        {
            if (!File.Exists(_saveFilePath))
                File.Create(_saveFilePath);

            StreamWriter streamWriter = new StreamWriter(_saveFilePath, false);
            streamWriter.Write(gameData.ToJson());
            streamWriter.Close();
        }
        catch (Exception e)
        {
            Debug.LogError(e); //o se puede activar un cartel que avise al usuario que hay un error
        }
        //lo ideal seria hacer un finally despues de catch para que siempre cierre el file por si se abre y salta error que se cierre
       
    }

    public void Load()
    {
        try
        {
            if (gameData == null)
                gameData = new GameData();
            if (File.Exists(_saveFilePath))
            {
                StreamReader streamReader = new StreamReader(_saveFilePath);
                gameData = GameData.FromJson(streamReader.ReadToEnd());
                streamReader.Close();
                
                OnLoadGameData?.Invoke(gameData);
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
     
    }
    
}
