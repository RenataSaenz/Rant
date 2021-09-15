using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource clickAudioSource;

    public void OnCliclkSound()
    {
        clickAudioSource.Play();
    }
}
