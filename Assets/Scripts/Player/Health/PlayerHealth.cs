using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour{

    public float startingHealth;
    public float currentHealth {get; private set;}
    float damageTime;
    bool hit;
    public float DBTime;

    public PlayerBombs Bomb;

    void Awake(){
        currentHealth = startingHealth;
    }

    void OnTriggerEnter2D(Collider2D other){

        if (other.tag == "Damage" || other.tag == "Enemy"){

            // Deathbombing var
            damageTime = Time.time;
            hit = true;

            if (currentHealth > 0)
                currentHealth--;
            else
                Destroy(gameObject);
          
            // Destroy Bullet
            if(other.tag == "Damage")
                Destroy(other.gameObject);

            //Debug.Log("Player: " + currentHealth);
        }
    }

    void Update(){
        if(hit)
            if (Time.time < damageTime + DBTime){
                if (Bomb.dbble){
                    currentHealth++;
                    hit = false;
                    Debug.Log("DEATHBOMB!");
                }
            }
            else
                hit = false;
    }
}
