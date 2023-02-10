using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;

public class HealthDrop : MonoBehaviour {
    
    private GameObject _player;
    private PlayerHealth _health;

    private void Start() {
        _player = GameObject.FindGameObjectWithTag("Player");
        _health = _player.GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject != _player) return;
        
        _health.currentHealth++;
        Destroy(gameObject);
    }
    
}
