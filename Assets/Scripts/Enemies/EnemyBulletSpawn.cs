using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawn : MonoBehaviour{

    public GameObject Shots;
    public Transform[] BulletSpawn;
    float nextShot;
    public float shotRate;

    // Update is called once per frame
    void FixedUpdate(){
        if (Time.time > nextShot){
            nextShot = Time.time + shotRate;
            foreach (Transform pos in BulletSpawn)
                Instantiate(Shots, pos.position, pos.rotation);
        }
    }
}
