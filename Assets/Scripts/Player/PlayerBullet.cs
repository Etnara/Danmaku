﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour{

    public float speed;

    // Start is called before the first frame update
    private void Start(){
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    } 
}
