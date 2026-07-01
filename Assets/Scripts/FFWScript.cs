using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FFWScript : MonoBehaviour{

    public Sprite[] sprites = new Sprite[2];
    private float speed_increase = 4f;

    void Start(){
        GetComponent<SpriteRenderer>().sprite = sprites[0];
    }

    void OnMouseDown(){
        GetComponent<SpriteRenderer>().sprite = sprites[1];
        Time.timeScale = speed_increase;
    }

    void OnMouseUp(){
        GetComponent<SpriteRenderer>().sprite = sprites[0];
        Time.timeScale = 1;
    }

}
