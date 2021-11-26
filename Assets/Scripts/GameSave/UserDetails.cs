using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class UserDetails
{
    public string name;
    public int score;

}

[System.Serializable]
public class RecentPlayers 
{
    public List<UserDetails> list;
    
    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }
 
    public static UserDetails FromJson(string jsonData)
    {
        return JsonUtility.FromJson<UserDetails>(jsonData);
    }
}
