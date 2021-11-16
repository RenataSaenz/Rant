using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour
{
    public string idIOS = "4447118";
    public string idANDROID = "4447119";
    private void Awake()
    {
#if UNITY_IOS
            Advertisement.Initialize(idIOS);
#endif
#if UNITY_ANDROID
            Advertisement.Initialize(idANDROID, true);
#endif
    }
}
