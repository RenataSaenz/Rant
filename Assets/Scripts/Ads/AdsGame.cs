using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsGame : MonoBehaviour
{
    public static AdsGame instance;

    string _id;

    Action _CallFinished, _CallFailed;

    private void Awake()
    {
#if UNITY_IOS
        id = "4447118";
#endif
#if UNITY_ANDROID
        _id = "4447119";
#endif
        Advertisement.Initialize(_id);
        instance = this;
    }

    public void Active(AdsType nameAds, Action methodFinished, Action methodFailed)
    {
        try
        {
            if (Advertisement.IsReady(nameAds.ToString()) && !Advertisement.isShowing)
            {
                ShowOptions options = new ShowOptions();
                options.resultCallback = HandleShowResult;
                _CallFailed = methodFailed;
                _CallFinished = methodFinished;
                Advertisement.Show(nameAds.ToString(), options);
            }
            else
            {
                methodFailed();
            }
        }
        catch
        {
            methodFailed();
        }

        

    }

    public void HandleShowResult(ShowResult result)
    {
        if (result == ShowResult.Finished)
            _CallFinished?.Invoke();
        else
            _CallFailed?.Invoke();
    }

    public enum AdsType
    {
        Interstitial_Android,
        Interstitial_iOS,
        Rewarded_Android,
        Rewarded_iOS
    }
}
