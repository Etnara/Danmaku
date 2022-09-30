using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour{

    public float startingHealth;
    public float currentHealth { get; private set; }
 

    void Awake(){
        currentHealth = startingHealth;
    }

    void OnTriggerEnter2D(Collider2D other){
        
        if (other.tag == "Player" || other.tag == "Player Bullet"){

            if (currentHealth > 0)
                currentHealth--;
            
            else
                Destroy(gameObject);


            // Destroy Bullet
            if (other.tag == "Player Bullet")
                Destroy(other.gameObject);

            Debug.Log("Enemy: " + currentHealth);
        }
    }
}
