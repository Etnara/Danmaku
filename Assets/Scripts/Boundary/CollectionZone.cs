using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CollectionZone : MonoBehaviour {
    
    private GameObject[] _items;
    private Rigidbody2D _rb;
    
    private void Awake() {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update() {
        _rb.AddForce(Vector2.zero); // Forces OnTriggerStay to be called while the player is not moving in the zone
    }
    
    private void OnTriggerStay2D(Collider2D other) {
        if (!other.gameObject.CompareTag("Collection Zone")) return;
        
        // change a var in itemPickup
        _items = GameObject.FindGameObjectsWithTag("Item");
        foreach (var obj in _items) {
            var script = obj.GetComponent<ItemPickup>(); 
            script.collect = (other.gameObject.CompareTag("Collection Zone"));
        }
    }
}
