using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class CurrentLanguage
{
    public static SystemLanguage inUseLanguage;
    public static bool usingLanguage = false;


    public static void SettedLanguage(SystemLanguage _lang)
    {
        inUseLanguage = _lang;
        usingLanguage = true;

    }
    
    

}
