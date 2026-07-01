using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BucketScript : MonoBehaviour
{
    public AudioSource fruit_pickup_sound;
    public AudioSource lose_sound;
    public int fruit_type;
    public GameObject score_text;
    [SerializeField]
    private Animator basket_get_anim;

    void OnTriggerEnter2D(Collider2D col){
        if (col.gameObject.GetComponent<FruitScript>().fruit_type == fruit_type){
            Destroy(col.gameObject);
            basket_get_anim.SetTrigger("play_correct");
            fruit_pickup_sound.Play(0);
            score_text.gameObject.GetComponent<ScoreScript>().AddPoint();
        }
        else{
            score_text.gameObject.GetComponent<ScoreScript>().LoseGame();
            Destroy(col.gameObject);
            lose_sound.Play(0);
        }
    }
}
