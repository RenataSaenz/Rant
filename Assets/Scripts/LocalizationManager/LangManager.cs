using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LangManager : MonoBehaviour
{
    public static LangManager instance;
    public Language selectedLanguage;

    public string externalURL = "https://drive.google.com/uc?export=download&id=1ExTsBQvokOQTomfKSp_ZJKiPPY6yCUjG";
    public Dictionary<Language, Dictionary<string, string>> languageManager = new Dictionary<Language, Dictionary<string, string>>();

    public event Action OnUpdate;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartCoroutine(DownloadCSV(externalURL));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (selectedLanguage == Language.eng)
                selectedLanguage = Language.spa;
            else
                selectedLanguage = Language.eng;

            OnUpdate?.Invoke();
        }
    }

    public string GetTranslate(string id)
    {
        if (!languageManager[selectedLanguage].ContainsKey(id))
            return "Error 404: Not found";
        else
            return languageManager[selectedLanguage][id];
    }

    public IEnumerator DownloadCSV(string url)
    {
        var www = new UnityWebRequest(url);
        www.downloadHandler = new DownloadHandlerBuffer();

        yield return www.SendWebRequest();

        languageManager = LanguageU.LoadCodex(www.downloadHandler.text);

        OnUpdate?.Invoke();
    }
}

public enum Language
{
    eng,
    spa
}
