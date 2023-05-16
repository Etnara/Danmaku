using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class KillBox : MonoBehaviour {
    
    private void OnTriggerExit2D(Collider2D other) {
        switch (other.tag) {
            case "Player":
            case "Player Bomb":
                return;
            case "Enemy":
                Destroy(other.transform.parent.gameObject);
                return;
            default: other.gameObject.SetActive(false);
                return;
        }
        if(other.CompareTag("Player") || other.CompareTag("Player Bomb")) return;
        if (other.CompareTag("Enemy")) {
            Destroy(other.transform.parent.gameObject);
            return;
        }
        other.gameObject.SetActive(false);
    }
}
