using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundScript : MonoBehaviour {
    private int status = 1;
    public Sprite[] sprites = new Sprite[2];
    public Button button;

    void Start(){
        if (AudioListener.volume == 0){
            button.image.sprite = sprites[0];
            status = 0;
        }
    }

    public void onClick(){
        if (status == 1){
            AudioListener.volume = 0;
            button.image.sprite = sprites[0];
            status = 0;
        }
        else{
            AudioListener.volume = 1;
            button.image.sprite = sprites[1];
            status = 1;
        }
        
    }
}
