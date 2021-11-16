using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class RewardedAds : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsShowListener
{
    public Button _showAdButton;
    string _androidAdId = "Rewarded_Android";
    string _iOSAdId = "Rewarded_iOS";
    string _adUnitId;

    void Start()
    {
#if UNITY_IOS
            _adUnitId = _iOSAdId;
#endif
#if UNITY_ANDROID
        _adUnitId = _androidAdId;
#endif
        _showAdButton.interactable = false;
    }

    public void LoadAd()
    {
        Advertisement.Load(_adUnitId); // debería ser (_adUnitId, this) pero tira error el this
    }

    public void OnInitializationComplete() // debería ser OnUnityAdsAdLoaded(string placementId)
    {
        _showAdButton.onClick.AddListener(ShowAd);
        _showAdButton.interactable = true;
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("Error al cargar ad");
    }

    public void ShowAd()
    {
        _showAdButton.interactable = false;
        Advertisement.Show(_adUnitId, this);
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log("Error al ejecutar ad");
    }

    public void OnUnityAdsShowStart(string placementId){}

    public void OnUnityAdsShowClick(string placementId){}

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("Ganaste una vida extra");
    }
}
