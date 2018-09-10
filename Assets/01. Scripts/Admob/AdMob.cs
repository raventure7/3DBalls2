using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;
using System;

public class AdMob : MonoBehaviour
{
    private static AdMob mAdMob;
    public static AdMob Instance
    {
        get
        {
            if (mAdMob == null)
            {
                mAdMob = FindObjectOfType<AdMob>();
            }
            return mAdMob;
        }
    }

#if UNITY_EDITOR
    string appId = "unused";
    string adUnitId = "unused";
    string adUnitInterstitialId = "unused";
    string adUnitVideoId = "unused";

#elif UNITY_ANDROID
    string appId                = "ca-app-pub-5962671645854399~4275546655";

    string adUnitId             = "ca-app-pub-5962671645854399/1090038166";

#elif UNITY_IPHONE
    string appId                = "ca-app-pub-5962671645854399~4275546655";

    string adUnitId             = "ca-app-pub-5962671645854399/1090038166";
#else
    string appId = "unexpected_platform";
    string adUnitId = "unexpected_platform";

#endif

    BannerView bannerView = null;
    InterstitialAd interstitialAd = null;
    RewardBasedVideoAd rewardBasedVideo = null;


    // Use this for initialization
    void Start()
    {
        MobileAds.Initialize(appId);
        // 배너 광고
        bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);
        AdRequest.Builder builder = new AdRequest.Builder();
        AdRequest request = builder.AddTestDevice(AdRequest.TestDeviceSimulator).
            AddTestDevice("61140F27CD138576").
            Build();
        //AdRequest request = builder.AddTestDevice(AdRequest.TestDeviceSimulator).Build();
        bannerView.LoadAd(request);
        bannerView.Show();
        //Debug.Log(SystemInfo.deviceUniqueIdentifier);
    }
}