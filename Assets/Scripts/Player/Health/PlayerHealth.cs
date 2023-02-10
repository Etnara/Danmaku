using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerHealth : MonoBehaviour {

    public float startingHealth;
    public float currentHealth;
    private float _damageTime;
    private bool _hit;
    public float DBTime;
    public float iTime;

    public PlayerBombs Bomb;
    public SpriteRenderer playerRenderer;

    private float _t;
    private bool _increasing;
    private SpriteRenderer _spriteRenderer;

    private void Awake() {
        _spriteRenderer = playerRenderer.GetComponent<SpriteRenderer>();
        currentHealth = startingHealth;
        _t = 0.0f;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (!other.CompareTag("Damage") && !other.CompareTag("Enemy")) return;
        
        // Invincible
        if (_damageTime > 0 && Time.time < _damageTime + iTime) {
            return;
        }

        // Deathbombing and Iframe var
        _damageTime = Time.time;                         //Debug.Log(damageTime);
        _hit = true;

        if (currentHealth > 0)
            currentHealth--;
        else
            Destroy(gameObject);
          
        // Destroy Bullet
        if(other.CompareTag("Damage"))
            // Destroy(other.gameObject);
            other.gameObject.SetActive(false);

        //Debug.Log("Player: " + currentHealth);
    }

    private void Update() {
        // Deathbomb
        if (!_hit) return;
        
        if (Time.time < _damageTime + DBTime) {

            if (!Bomb.dbble) return;
            
            currentHealth++;
            _hit = false;
            Debug.Log("DEATHBOMB!");
        }
        else
            _hit = false;
    }

    private void FixedUpdate() {
    
         // iFrame Animation
        if (_damageTime > 0 && Time.time < _damageTime + iTime) {
            
            // Increasing or Decreasing
            if (_t >= 0.99)
                _increasing = false;
            if (_t <= 0.01)
                _increasing = true;

            // +- t
            if (_increasing)
                _t += 1/50f;
            else
                _t -= 1/50f;

            // Lerp
            _spriteRenderer.color = new Color (255, 0, 0, _t);
            // Debug.Log(t);
                    
        } else
            // Correction because floating point rounding is dumb
            _spriteRenderer.color = new Color (255, 0, 0, 1);
 

    
    }

}
