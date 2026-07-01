using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathScript : MonoBehaviour{
    public int direction;

    void OnTriggerStay2D(Collider2D col){
        col.gameObject.GetComponent<FruitScript>().direction = direction;
    }
}
