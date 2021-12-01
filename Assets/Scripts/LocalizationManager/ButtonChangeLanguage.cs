using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class ButtonChangeLanguage : MonoBehaviour
{
    public Button button;
    [SerializeField]
    private Flag[] flags;

    private void Awake()
    {
        button.GetComponent<Image>();
    }

    private void Start()
    {
        SetFlag();
    }

    public void ChangeFlag()
    {
        LocalizationManager.Instance.SwitchLanguage();
        SetFlag();
    }
    
    private void SetFlag()
    {
        Flag f = Array.Find(flags, flag => flag.language == LocalizationManager.language);
        
        if (f == null)
        {
            Debug.LogWarning("Flag: " + LocalizationManager.language + " not found!");
            return;
        }
        //Debug.Log("Changed to: " + LocalizationManager.language);
        button.image.sprite = f.sprite;
    }
}

[System.Serializable]
public class Flag
{
    public SystemLanguage language;

    public Sprite sprite;
}
