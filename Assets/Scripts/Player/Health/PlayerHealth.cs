using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour{

    public float startingHealth;
    public float currentHealth {get; private set;}

    void Awake(){
        currentHealth = startingHealth;
    }

    void OnTriggerEnter2D(Collider2D other){

        if (other.tag == "Damage" || other.tag == "Enemy"){

            if (currentHealth > 0)
                currentHealth--;
            else
                Destroy(gameObject);
            
            // Destroy Bullet
            if(other.tag == "Damage")
                Destroy(other.gameObject);

            Debug.Log("Player: " + currentHealth);
        }
    }
}
