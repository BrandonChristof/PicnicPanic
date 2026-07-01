using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
using GoogleMobileAds.Mediation.UnityAds.Api;

public static class Ads {

    private static bool ads_initialized = false;
    private static string interstitial_id = "ca-app-pub-3940256099942544/1033173712"; // fake
    private static string banner_id = "ca-app-pub-3940256099942544/6300978111"; // fake
    static BannerView _bannerView;
    static InterstitialAd _interstitialAd;

    public static void InitializeAds(){
        if (!ads_initialized){
            MobileAds.Initialize((initStatus) => {
                Dictionary<string, AdapterStatus> map = initStatus.getAdapterStatusMap();
                foreach (KeyValuePair<string, AdapterStatus> keyValuePair in map){
                    string className = keyValuePair.Key;
                    AdapterStatus status = keyValuePair.Value;
                    switch (status.InitializationState){
                        case AdapterState.NotReady:
                            // The adapter initialization did not complete.
                            MonoBehaviour.print("Adapter: " + className + " not ready.");
                            break;
                        case AdapterState.Ready:
                            // The adapter was successfully initialized.
                            MonoBehaviour.print("Adapter: " + className + " is initialized.");
                            break;
                    }
                }
            });
            LoadInterstitialAd();
            ads_initialized = true;
        }
        LoadBannerAd();
    }

    public static void LoadBannerAd(){
        if(_bannerView == null){
            CreateBannerView();
        }
        var adRequest = new AdRequest();
        _bannerView.LoadAd(adRequest);
    }
    
    public static void CreateBannerView(){
        if (_bannerView != null){
            DestroyBannerView();
        }
        AdSize adaptiveSize = AdSize.GetPortraitAnchoredAdaptiveBannerAdSizeWithWidth(AdSize.FullWidth);
        _bannerView = new BannerView(banner_id, adaptiveSize, AdPosition.Bottom);
        
    }
    
    public static void DestroyBannerView(){
        if (_bannerView != null){
            _bannerView.Destroy();
            _bannerView = null;
        }
    }

    public static void DestroyInterstitial(){
        if (_interstitialAd != null){
            _interstitialAd.Destroy();
            _interstitialAd = null;
        }
    }

    public static void LoadInterstitialAd(){
        if (_interstitialAd != null){
            _interstitialAd.Destroy();
            _interstitialAd = null;
        }

        var adRequest = new AdRequest();

        InterstitialAd.Load(interstitial_id, adRequest, (InterstitialAd ad, LoadAdError error) => {
            if (error != null || ad == null){
                Debug.LogError("Iterstitial ad failed to load: " + error);
                return;
            }
            Debug.Log("Iterstitial ad loaded: " + ad.GetResponseInfo());
            _interstitialAd = ad;
            RegisterReloadHandler(_interstitialAd);
        });
    }

    public static void ShowInterstitialAd(){
        if (_interstitialAd != null && _interstitialAd.CanShowAd()){
            Debug.Log("Showing iterstitial ad");
            _interstitialAd.Show();
        }
        else{
            Debug.LogError("Interstitial ad not ready");
        }
    }

    private static void RegisterReloadHandler(InterstitialAd interstitialAd){
        interstitialAd.OnAdFullScreenContentClosed += () => {
            Debug.Log("Interstitial ad full screen closed");
            LoadInterstitialAd();
        };

        interstitialAd.OnAdFullScreenContentFailed += (AdError error) => {
            Debug.LogError("Interstitial ad failed to open: " + error);
            LoadInterstitialAd();
        };
    }
}
