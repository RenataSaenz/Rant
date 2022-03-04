using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveRewardJson : MonoBehaviour
{
    public static SaveRewardJson instance;

    public int numberGame = 1;
    public WeaponsWon weaponsGained;
    public event Action<WeaponsWon> OnLoadRewardData;
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
        DontDestroyOnLoad(this);

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
            StreamWriter streamWriter = new StreamWriter(_saveFilePath, false);
            streamWriter.Write(weaponsGained.ToJson());
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
            if (weaponsGained == null)
                weaponsGained = new WeaponsWon();
            
            if (File.Exists(_saveFilePath))
            {
                StreamReader streamReader = new StreamReader(_saveFilePath);
                weaponsGained = JsonUtility.FromJson<WeaponsWon>(streamReader.ReadToEnd());
                streamReader.Close();
                
                OnLoadRewardData?.Invoke(weaponsGained);
            }
            else
            {
                File.Create(_saveFilePath);
                weaponsGained.list.Add(new ItemWeapon{id = 5});
                weaponsGained.list.Add(new ItemWeapon{id = 6});
            }
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }
}
