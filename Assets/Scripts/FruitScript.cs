using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitScript : MonoBehaviour{

    public int fruit_type;
    public float speed;
    public int direction;
    void Update(){
        if (direction == 0){
            transform.position += new Vector3(0f, -speed, 0f) * Time.deltaTime;
        }
        else if (direction == 1){
            transform.position += new Vector3(speed, 0f, 0f) * Time.deltaTime;
        }
        else if (direction == -1){
            transform.position += new Vector3(-speed, 0f, 0f) * Time.deltaTime;
        }
    }
}
