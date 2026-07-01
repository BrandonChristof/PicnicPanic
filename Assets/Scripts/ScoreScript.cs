using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public int score = 0;
    public int hi_score;
    public TextMeshProUGUI score_text;
    public TextMeshProUGUI hi_score_text;
    public TextMeshProUGUI end_score_text;
    public GameObject end_score_title;
    public GameObject end_score_record_title;
    public GameObject record_flash;
    public TextMeshProUGUI end_hi_score_text;
    public Sprite[] end_background = new Sprite[2];
    public GameObject manager;

    public GameObject end_screen;

    void Start(){
        hi_score = SaveSystem.LoadData();
        hi_score_text.text = "Best: " + hi_score.ToString();
    }

    public void AddPoint(){
        score += 1;
        score_text.text = score.ToString();
    }

    public void LoseGame(){
        if (score > hi_score){
            SaveSystem.SaveGame(score);
            end_screen.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = end_background[1];
            end_hi_score_text.text = score.ToString();
            end_score_record_title.SetActive(true);
            end_score_title.SetActive(false);
            record_flash.SetActive(true);
        }
        else{
            end_screen.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = end_background[0];
            end_hi_score_text.text = hi_score.ToString();
        }
        manager.SetActive(false);
        Time.timeScale = 1f;
        end_score_text.text = score.ToString();
        end_screen.SetActive(true);
    }

    public void ResetGame(){
        SaveSystem.SaveGame(0);
    }
}
