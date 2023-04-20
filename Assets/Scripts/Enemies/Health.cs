using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour{

    public float startingHealth;
    public float CurrentHealth { get; private set; }
    private void Awake(){
        CurrentHealth = startingHealth;
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (!other.CompareTag("Player") && !other.CompareTag("Player Bullet")) return;
        
        // Health
        CurrentHealth--;
        if (CurrentHealth <= 0) {
            Destroy(transform.parent.gameObject);
        }

            
        // Destroy Bullet
        if (other.CompareTag("Player Bullet"))
            other.gameObject.SetActive(false);
    }

    private void OnDestroy() {
        Debug.Log("Kill");
        Debug.Log("Before Kill: " + FindObjectOfType<EnemySpawner>().currentEnemies);
        FindObjectOfType<EnemySpawner>().currentEnemies--;
        Debug.Log("After Kill: " + FindObjectOfType<EnemySpawner>().currentEnemies);
    }
}
