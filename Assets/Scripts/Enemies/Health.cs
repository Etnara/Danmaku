using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour{

    public float startingHealth;
    public float CurrentHealth { get; private set; }
    public GameObject[] pools;
    private void Awake(){
        CurrentHealth = startingHealth;
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (!other.CompareTag("Player") && !other.CompareTag("Player Bullet")) return;
        
        // Health
        CurrentHealth--;
        if (CurrentHealth <= 0) {
            Destroy(gameObject);
            foreach (var obj in pools)
                // Call DisablePool() on the object's ObjectPool component
                obj.GetComponent<ObjectPool>().DisablePoolStart();
                // obj.SetActive(false);
        }

            
        // Destroy Bullet
        if (other.CompareTag("Player Bullet"))
            other.gameObject.SetActive(false);
    }
}
