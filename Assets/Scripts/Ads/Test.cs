using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public AdsGame.AdsType nameAds;

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
        ManagerUI.instance.AdsRewards();
    }
}
