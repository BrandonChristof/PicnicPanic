using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour{

    public GameObject score;
    public void RestartGame(){
        int _score = score.gameObject.GetComponent<ScoreScript>().score;
        int _hi_score = score.gameObject.GetComponent<ScoreScript>().hi_score;
        if (_score >= 20 && _score <= _hi_score){
            Ads.ShowInterstitialAd();
        }
        SceneManager.LoadScene(0);
    }
}
