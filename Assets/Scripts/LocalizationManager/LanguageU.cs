/*using System.Collections.Generic;
using UnityEngine;
using System;

public class LanguageU : MonoBehaviour
{
    public static Dictionary<SystemLanguage, Dictionary<string, string>> LoadCodex(string source)
    {
        Debug.Log("entro");
        var codex = new Dictionary<SystemLanguage, Dictionary<string, string>>();

        var columnToIndex = new Dictionary<string, int>();
        bool first = true;

        string[] rows = source.Split('\r');

        foreach (var row in rows)
        {
            string[] cells = row.Split(',');

            if (first)
            {
                first = false;
                for (int i = 0; i < cells.Length; i++)
                {
                    columnToIndex[cells[i]] = i;
                }
            }
            else
            {
                string langName = cells[columnToIndex["Idioma"]];

                SystemLanguage lang;

                lang = (SystemLanguage)Enum.Parse(typeof(SystemLanguage), langName);

                var idName = cells[columnToIndex["ID"]];

                var text = cells[columnToIndex["Texto"]];

                if (!codex.ContainsKey(lang))
                    codex[lang] = new Dictionary<string, string>();

                codex[lang][idName] = text;
            }

        }

        return codex;
    }
}*/
