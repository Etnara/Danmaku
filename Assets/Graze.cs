using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graze : MonoBehaviour{

    public float graze { get; private set; }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Damage")
            graze++;
    }
}
