using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   
    void Start()
    {
        SoundManager.instance.Play(SoundManager.Types.MainSong);
    }
    void Update()
    {
        
    }
}
