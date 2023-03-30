using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDestroy : MonoBehaviour{

    void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Damage"))
            other.gameObject.SetActive(false);
            // Destroy(other.gameObject);
    }

}
