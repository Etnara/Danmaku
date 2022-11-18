using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graze : MonoBehaviour{

    public float Grazes { get; private set; }
    private Player _player;

    private void Awake() {
        _player = gameObject.GetComponentInParent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (!other.CompareTag("Damage")) return;
        Grazes++;
        _player.ShotLevel(Grazes);
    }

}
