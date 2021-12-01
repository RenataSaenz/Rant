﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using MiniJSON;
using TMPro.EditorUtilities;
using UnityEngine.SceneManagement;

public class LocalizationManager : MonoBehaviour
{
    public string rootDirectory = "/Resources/Localization";
    public static LocalizationManager Instance{ get; private set; }

    public static Dictionary<SystemLanguage, Dictionary<string, string>> translations = new Dictionary<SystemLanguage, Dictionary<string, string>>();
    
    public static SystemLanguage language; //= SystemLanguage.English;

    public event Action ChangeLanguage;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            LoadTranslations();
        }
        else Destroy(this);

        if (!CurrentLanguage.usingLanguage)
        {
            language = Application.systemLanguage;
        }
        else
        {
            language = CurrentLanguage.inUseLanguage;
        }

    }

    void Start()
    {
        Debug.Log("Start");
        InvokeLanguage();
    }

    public void InvokeLanguage()
    {
        Debug.Log("InvokeLanguage");
        ChangeLanguage?.Invoke();
    }
    
    public void SwitchLanguage()
    {
        Debug.Log("SwitchLanguage");
        language = language == SystemLanguage.Spanish ? SystemLanguage.English : SystemLanguage.Spanish;
        InvokeLanguage();
        CurrentLanguage.SettedLanguage(language);
    }
    
    private void LoadTranslations(){
        translations = new Dictionary<SystemLanguage, Dictionary<string, string>>();
        
        var allFiles = new List<string>();
        foreach (var file in Directory.GetFiles(Application.dataPath + $"{rootDirectory}/", "*.json", SearchOption.AllDirectories)) {
            var fileName = file.Substring(file.IndexOf("Localization", StringComparison.Ordinal))
                .Replace(@"\", @"/");
            allFiles.Add(fileName);
        }
        
        foreach (var file in allFiles){
            var asset = Resources.Load<TextAsset>(file.Replace(".json", ""));
            
            var data = asset.text;
            
            var parsedData = (Dictionary<string, object>)Json.Deserialize(data);
            var split   = file.Split('/');
            
            SetTranslations(parsedData, split[split.Length-1].Replace(".json",""), split[split.Length - 2]);
        }
    }
    
    private void SetTranslations(Dictionary<string, object> fileContent, string fileName, string language) {
        var lang = LanguageMapper.Map(language.ToUpper());

        foreach (var item in fileContent) {
            if (!translations.ContainsKey(lang)) translations.Add(lang, new Dictionary<string, string>());
            
            translations[lang].Add($"{fileName}/{item.Key}", item.Value.ToString());
           // Debug.Log($"{lang} --- {fileName}/{item.Key} --- {item.Value}");
        }
    }
    
    public string GetTranslate(string id)
    {
        Debug.Log("GetTranslate");
        if (!translations[language].ContainsKey(id))
        {
            Debug.LogError($"Key '{id}' for language '{language}' not found");
            return id; 
        }
        else
            return translations[language][id];
    }
}

