using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ManagerUI : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject pausedMenu;
    public Image cameraShutDown;
    public float speedFade;
    public AudioSource clickAudioSource;
    public Image stars0;
    public Image stars1;
    public Image stars2;
    public Image stars3;
    private void Start()
    {
        EventManager.Subscribe("GameOver", FadeOn);

        if (cameraShutDown != null)
            cameraShutDown.color = new Color(cameraShutDown.color.r, cameraShutDown.color.g, cameraShutDown.color.b, 0);

    }

    private void Update()
    {
       ShowScore();
       TotalPoints();
    }
    public void ShowScore()
    {
        var score = TotalScore.totalScore;
        text.text = "SCORE: " + score.ToString();
    }
    public void TotalPoints()
    {
       var totalScore = TotalScore.totalScore;

        if (stars0 != null)
        {
            stars0.enabled = false;
            stars1.enabled = false;
            stars2.enabled = false;
            stars3.enabled = false;

            if (totalScore == 0)
            {
                stars0.enabled = true;
            }
            else if (totalScore > 0 && totalScore <= 3)
            {
                stars1.enabled = true;
            }
            else if (totalScore > 3 && totalScore < 7)
            {
                stars2.enabled = true;
            }
            else
            {
                stars3.enabled = true;
            }
        }
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
        StartCoroutine(FadeActive());
    }

    public IEnumerator FadeActive()
    {
        Color fade = cameraShutDown.color;
        fade.a = 1;

        while (cameraShutDown.color.a < 1)
        {
            cameraShutDown.color = Color.Lerp(cameraShutDown.color, fade, speedFade * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

}
