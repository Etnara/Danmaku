using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour{

    public float startingHealth;
    public float currentHealth {get; private set;}
    float damageTime;
    bool hit;
    public float DBTime;
    public float iTime;

    public PlayerBombs Bomb;
    public SpriteRenderer playerRenderer;

    float t;
    bool increasing;

    void Awake(){
        currentHealth = startingHealth;
        t = 0.0f;
    }

    void OnTriggerEnter2D(Collider2D other){

        
            

        if (other.tag == "Damage" || other.tag == "Enemy"){
            
            // Invincible
            if (damageTime > 0 && Time.time < damageTime + iTime){
                return;
            }

            // Deathbombing and Iframe var
            damageTime = Time.time;                         //Debug.Log(damageTime);
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
        // Deathbomb
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

    void FixedUpdate() {
    
         // iFrame Animation
        if (damageTime > 0 && Time.time < damageTime + iTime) {
            
            // Increasing or Decreasing
            if (t >= 0.99)
                increasing = false;
            if (t <= 0.01)
                increasing = true;

            // +- t
            if (increasing)
                t += 1/50f;
            else
                t -= 1/50f;

            // Lerp
            playerRenderer.GetComponent<SpriteRenderer>().color = new Color (255, 0, 0, t);
            // Debug.Log(t);
                    
        } else
            // Correction because floating point rounding is dumb
            playerRenderer.GetComponent<SpriteRenderer>().color = new Color (255, 0, 0, 1);
 

    
    }

}
