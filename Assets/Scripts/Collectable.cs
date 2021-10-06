using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Collectable : MonoBehaviour, ICollectable
{
    public int collectableValue = 1;
    public AudioSource audioSource;

    public void Collect()
    {
        SoundManager.instance.Play(SoundManager.Types.Collect);
        //ScoreManager.instance.ChangeScore(collectableValue);
        TotalScore.SumScore(collectableValue);
        gameObject.SetActive(false);
    }
}
