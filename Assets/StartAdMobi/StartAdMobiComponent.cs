#define START_AD_MOBI
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAdMobiComponent : MonoBehaviour {

    public string appId;
    public string lang = LANGUAGE_RU;

    // variants adPlacedId
    public const string AD_PLACEID_DEFAULT = "default";
    public const string AD_PLACEID_WITHADTEXT = "default_ad";
    public const string AD_PLACEID_CUSTOM = "custom";

    //variants language
    public const string LANGUAGE_RU = "ru";
    public const string LANGUAGE_EN = "en";

    //variants bannerPosition
    public const int ALIGN_TOP = 10;
    public const int ALIGN_BOTTOM = 12;
    public const int ALIGN_CENTER = 13;

 
    private static StartAdMobiComponent _instance;

    private AndroidJavaObject _startAdMobiHelper;


    void Awake()
    {
        _instance = this;
        #if START_AD_MOBI
            if (Application.platform != RuntimePlatform.Android) {
                return;
            }
            _InitializeLibrary();

            if (Application.systemLanguage == SystemLanguage.Russian) {
                lang = LANGUAGE_RU;
            } else {
                lang = LANGUAGE_EN;
            }
            _SetAppIDandLanguage(appId, lang);
        #endif
    }

    public static StartAdMobiComponent GetInstance()
    {
        return _instance;
    }

    void Start()
    {
        if (appId == "") {
            Debug.LogError("StartAdMobiComponent::Start [ERROR NO SET APP_ID FOR SMART_AD_MOBI]");
        }
    }

    private void _InitializeLibrary()
    {
        #if START_AD_MOBI
            if (Application.platform == RuntimePlatform.Android) {
                _startAdMobiHelper = new AndroidJavaObject("shcherban.com.startadmobi.StartAdMobiHelper");
            }
        #endif
    }

    //need call beforecall method Show
    private void _SetAppIDandLanguage(string appId, string lang)
    {
        #if START_AD_MOBI
            if (Application.platform == RuntimePlatform.Android) {
                _startAdMobiHelper.Call("SetAppIDandLanguage", appId, lang);
            }
        #endif
    }

    public void ShowAdvert(int align, string adPlaced)
    {
        #if START_AD_MOBI
            if (Application.platform == RuntimePlatform.Android) {
                _startAdMobiHelper.Call("ShowAdvert", align, adPlaced);
            }
        #endif
    }

    public void HideAdvert()
    {
        #if START_AD_MOBI
            if (Application.platform == RuntimePlatform.Android) {
                _startAdMobiHelper.Call("HideAdvert");
            }
        #endif
    }


    //callbacks
    public void onReceiveAd()
    {
        Debug.Log("StartAdMobiComponent::onReceiveAd");
    }
    public void onShowedAd()
    {
        Debug.Log("StartAdMobiComponent::onShowedAd");
    }
    public void onError(string error)
    {
        Debug.Log("StartAdMobiComponent::onError " + error);
    }
   
    public void onAdClicked()
    {
        Debug.Log("StartAdMobiComponent::onAdClicked");
    }

    public void noAdFound()
    {
        Debug.Log("StartAdMobiComponent::noAdFound");
    }
}
