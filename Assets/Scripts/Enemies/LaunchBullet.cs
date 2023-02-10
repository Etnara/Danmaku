using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchBullet : MonoBehaviour{

    public float speed;

     private void OnEnable() {
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;
    }
}
