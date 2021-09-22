using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    [SerializeField]
    private float _timeForTransition;

    private void Start()
    {
        EventManager.Subscribe("GameOver", YouLost);
        EventManager.Subscribe("GameWon", YouWin);
    }

    public void YouLost(params object[] parameters)
    {
        StartCoroutine(WaitForLoadScene(3));
    }
    IEnumerator WaitForLoadScene(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("YouLost");
    }
    public void YouWin(params object[] parameters)
    {
        StartCoroutine(WaitForWinScene(_timeForTransition));
    }
    IEnumerator WaitForWinScene(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("YouWon");
    }
    public void Play()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Picnic");
    }

    public void Rules()
    {
        SceneManager.LoadScene("Rules");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Exit()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
