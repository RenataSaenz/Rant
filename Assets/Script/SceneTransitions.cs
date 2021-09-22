using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    private void Start()
    {
        EventManager.Subscribe("GameOver", YouLost);
    }

    public void YouLost(params object[] parameters)
    {
        //StartCoroutine(WaitForLoadScene((float)parameters[0]));

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
