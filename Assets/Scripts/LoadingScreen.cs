using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    public Text progressText;
    void Start()
    {
        StartCoroutine(Loading());
    }

    IEnumerator Loading()
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync("Picnic");
        var WaitForEndOfFrame = new WaitForEndOfFrame();
        loadOperation.allowSceneActivation = false;

        while (loadOperation.progress < 0.9f)
        {
            progressText.text = ((loadOperation.progress / 0.9f) * 100) + "%";
            yield return WaitForEndOfFrame;
        }

        progressText.text = "Press space to play";

        while (!Input.GetKey(KeyCode.Space))
        {
            yield return WaitForEndOfFrame;
        }

        loadOperation.allowSceneActivation = true; 
    }
    
}
