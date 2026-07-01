using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class StartScript : MonoBehaviour{

    public GameObject randomizer;
    public GameObject spawner;
    public TextMeshProUGUI start_text;

    void Start(){
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 61;
        Ads.InitializeAds();
    }

    void OnMouseDown(){
        randomizer.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
        start_text.gameObject.SetActive(false);
    }
}
