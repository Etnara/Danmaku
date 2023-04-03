using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDrop : MonoBehaviour
{
    private GameObject _player;
    private PlayerBombs _bombs;

    private void Start() {
        _player = GameObject.FindGameObjectWithTag("Player");
        _bombs = _player.GetComponent<PlayerBombs>();
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject != _player) return;
        
        _bombs.currentBombs++;
        Destroy(gameObject);
    }
}
