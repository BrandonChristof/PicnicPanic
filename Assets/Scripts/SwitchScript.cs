using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    public int direction = -1;
    public Sprite[] sprites = new Sprite[2];
    public AudioSource switch_sound;
    void OnMouseDown(){
        direction *= -1;
        switch_sound.Play(0);
        if (direction == -1){
            GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
        else if (direction == 1){
            GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
        
    }

    void OnTriggerEnter2D(Collider2D col){
        col.gameObject.GetComponent<FruitScript>().direction = direction;
    }
}
