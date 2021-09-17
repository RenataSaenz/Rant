﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ManagerUI : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject pausedMenu;
    public Image cameraShutDown = null;
    public float speedFade;
    public AudioSource clickAudioSource;
    private int _totalScore;
    
    public Animator fadeOnAnimator;
    public Ant ant;

    [Header("Stars")]
    [SerializeField]
    private Image _star0 = null;
    [SerializeField]
    private Image _star1 = null;
    [SerializeField]
    private Image _star2 = null;
    [SerializeField]
    private Image _star3 = null;


 
    private void Start()
    {
        if (_star1 != null)
        {
            _star0.enabled = false;
            _star1.enabled = false;
            _star2.enabled = false;
            _star3.enabled = false;
        }

        EventManager.Subscribe("GameOver", FadeOn);

        fadeOnAnimator.SetBool("FadeOnActive", true);
        if (cameraShutDown !=null)
            cameraShutDown.canvasRenderer.SetAlpha(0f);

    }

    public void ChangeScore(int score)
    {
        text.text = "SCORE: " + score.ToString();
    }

    public void OnCliclkSound()
    {
        clickAudioSource.Play();
    }

    public void ActivePause()
    {
        pausedMenu.SetActive(true);
    }

    public void InactivePause()
    {
        pausedMenu.SetActive(false);
    }

    public void FadeOn(params object[] parameters)
    {
        //fadeOnAnimator.SetBool("FadeOnActive", true);
        Debug.Log("Entre");

    }

    /*public IEnumerator FadeActive()
    {
        yield return new WaitForSeconds(ant.dieTimer);
        fadeOnAnimator.SetTrigger("FadeOn");
    }*/

    public void StarsSet()
    {
        while (_star1 != null)
        {
            if (_totalScore <= 0)
            {
                _star0.enabled = true;
            }
            else if (_totalScore <= 10)
            {
                _star1.enabled = true;
            }
            else if (_totalScore <= 20)
            {
                _star2.enabled = true;
            }
            else if (_totalScore > 20)
            {
                _star3.enabled = true;
            }
        }
    }

}
