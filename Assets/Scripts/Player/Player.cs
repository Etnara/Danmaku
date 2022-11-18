using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    
    // Movement
    private Rigidbody2D _component;
    public float speed;
    public float focus;
    
    // Shooting
    [Space(10)]
    public float shotRate;
    public float[] upgradeGraze;
    private int _shotLevel;
    private float _nextShot;

    // GameObjects
    [Header("GameObjects")]
    public Transform bulletSpawn;
    
    private GameObject[][] _shots;
    public GameObject[] shots1;
    public GameObject[] shots2;

    private GameObject[][] _focusedShots;
    public GameObject[] focusedShots1;
    public GameObject[] focusedShots2;

    private void Awake() {
        _component = GetComponent<Rigidbody2D>();
        _shots = new[] { shots1, shots2 };
        _focusedShots = new[] { focusedShots1, focusedShots2 };
    }

    private void FixedUpdate(){
        if (Input.GetKey("z") && Time.time > _nextShot) {
            _nextShot = Time.time + shotRate;
            SpawnBullets(Input.GetKey(KeyCode.LeftShift) ? _focusedShots[_shotLevel] : _shots[_shotLevel]);
        }
        
        var movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        _component.velocity = Input.GetKey(KeyCode.LeftShift) ? movement * (speed * focus): movement * speed;
    }

    private void SpawnBullets(IEnumerable<GameObject> bullets){
        foreach (var b in bullets)
            Instantiate(b, bulletSpawn.position, bulletSpawn.rotation);
    }
    
    public void ShotLevel(float graze) {
        if (_shotLevel == _shots.Length - 1)
            return;
        for (var i = 0; i < upgradeGraze.Length; i++) {
            if (Math.Abs(graze - upgradeGraze[i]) > 0.5) continue;
                Debug.Log("Upgrade");
                _shotLevel = i + 1;
        }
    }
}
