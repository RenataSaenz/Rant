using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ManagerUI : MonoBehaviour
{
    public TextMeshProUGUI text;
    public GameObject pausedMenu;
    public Image cameraShutDown;
    //public float speedFade;
    public AudioSource clickAudioSource;
    public Animator fadeOnAnimator;
    public Ant ant;
    private void Start()
    {
        EventManager.Subscribe("GameOver", FadeOn);
<<<<<<< Updated upstream
        fadeOnAnimator.SetBool("FadeOnActive", true);
        //cameraShutDown.canvasRenderer.SetAlpha(0f);
=======

        if (cameraShutDown != null)
            cameraShutDown.color = new Color(cameraShutDown.color.r, cameraShutDown.color.g, cameraShutDown.color.b, 0);

>>>>>>> Stashed changes
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

}
