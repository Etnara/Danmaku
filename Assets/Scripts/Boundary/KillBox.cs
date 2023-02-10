using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBox : MonoBehaviour {
    
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player") || other.CompareTag("Player Bomb")) return;
        other.gameObject.SetActive(false);
    }
}
