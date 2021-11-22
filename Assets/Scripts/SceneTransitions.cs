using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    public ManagerUI managerUI;

    [SerializeField]
    private float _timeForTransition;

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
    {
        StartCoroutine(WaitForLoadScene(2));
    }
    IEnumerator WaitForLoadScene(float time)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene("YouLost");
    }

    public void Play()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Picnic");
        PointsContoller.totalScore = 0;
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
