using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [Header("Speed")]
    public float speed;
    public float focus;

    [Space(10)]
    public float shotRate;


    [Header("Objects")]
    public GameObject[] Shots;
    public GameObject[] focusedShots;
    public Transform BulletSpawn;

    float nextShot;

    /*void Update(){

        //Debug.Log(nextShot);
        if (Input.GetKey("z") && Time.time > nextShot) {
            nextShot = Time.time + shotRate;

            if (Input.GetKey(KeyCode.LeftShift))
                spawnBullets(focusedShots);
            else
                spawnBullets(Shots);

        }

        

    }*/

    void FixedUpdate(){
        if (Input.GetKey("z") && Time.time > nextShot){
            nextShot = Time.time + shotRate;

            if (Input.GetKey(KeyCode.LeftShift))
                spawnBullets(focusedShots);
            else
                spawnBullets(Shots);

        }

        var rigidbody = GetComponent<Rigidbody2D>();

        float shift = 1.0f;

        if (Input.GetKey(KeyCode.LeftShift))
            shift = focus;

        var movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        rigidbody.velocity = movement * speed * shift;

    }

    void spawnBullets(GameObject[] bullets){
        foreach (GameObject b in bullets)
            Instantiate(b, BulletSpawn.position, BulletSpawn.rotation);
    }
    
    /*void FixedUpdate(){

        var rigidbody = GetComponent<Rigidbody2D>();
        
        float shift = 1.0f;

        if (Input.GetKey(KeyCode.LeftShift))
            shift = focus;

        var movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

        rigidbody.velocity = movement * speed * shift;
        
    }*/
}
