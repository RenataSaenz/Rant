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
        audioSource.Play();
        ScoreManager.instance.ChangeScore(collectableValue);
        Destroy(gameObject);
    }
}
