using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    //public Vector3 positionPlayer;  //puedo guardar la posicion para respawn
    public string name;
    public int collectPointInt;
    //public List<int> collectPoints = new List<int>();
    

    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }

    public static GameData FromJson(string jsonData)
    {
        return JsonUtility.FromJson<GameData>(jsonData);
    }
}
