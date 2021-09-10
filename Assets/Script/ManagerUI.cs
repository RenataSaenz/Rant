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
    public float speedFade;

    private void Start()
    {
        EventManager.Subscribe("GameOver", FadeOn);
        cameraShutDown.canvasRenderer.SetAlpha(0f);
    }

    public void ChangeScore(int score)
    {
        text.text = "SCORE: " + score.ToString();
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

    IEnumerator FadeActive()
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
