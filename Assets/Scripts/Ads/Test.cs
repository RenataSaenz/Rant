using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Test : MonoBehaviour
{
    public AdsGame.AdsType nameAds;
    //public event Action OnPlayRewards;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Active();
    }

    public void Active()
    {
        AdsGame.instance.Active(nameAds, FinishAds, GameOver);
    }

    void GameOver()
    {
        Debug.Log("Perdiste");
    }

    void FinishAds()
    {
      //  OnPlayRewards?.Invoke();
      //  ManagerUI.Instance.AdsRewards();
      ManagerUI.AdsRewards();
    }
}
