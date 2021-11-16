using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public RewardedAds rewardedAds;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            rewardedAds.LoadAd();
    }
}
