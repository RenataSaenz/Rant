using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    public ManagerUI managerUI;

    [SerializeField]
    private float _timeForTransition;

    [SerializeField] private GameObject _pauseMenu;

    private void Start()
    {
        EventManager.Subscribe("GameOver", YouLost);
        EventManager.Subscribe("GameWon", YouWon);
    }

    public void Resume()
    {
        managerUI.InactivePause();
        Time.timeScale = 1f;
    }

    public void YouWon(params object[] parameters)
    {
        SceneManager.LoadScene("YouWon");
       // ScoreManager.instance.PointsContoller();
    }

    public void YouLost(params object[] parameters)
    {Debug.Log("YouLost");
        StartCoroutine(WaitForLoadScene(2));
    }
    IEnumerator WaitForLoadScene(float time)
    {
        Debug.Log("LoadScreen");
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("YouLost");
    }

    public void Play()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Picnic");
        PointsContoller.totalScore = 0;
    } 
    public void Continue()
    {
        Time.timeScale = 1f;
        _pauseMenu.SetActive(false);
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
