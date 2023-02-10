using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

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
    
    private ObjectPool[][] _shots;
    public ObjectPool[] shots1;
    public ObjectPool[] shots2;

    private ObjectPool[][] _focusedShots;
    public ObjectPool[] focusedShots1;
    public ObjectPool[] focusedShots2;

    public GameObject[] poolLevels;
    
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

    private void SpawnBullets(IEnumerable<ObjectPool> bullets) {
        foreach (var b in bullets) {
            // Instantiate(b.GetPooledObject(), bulletSpawn.position, bulletSpawn.rotation);
            // Tuple: bulletObj, offset, rotation
            var shot = b.GetPooledObject();
            shot.Item1.transform.position = shot.Item2 + bulletSpawn.position; 
            shot.Item1.transform.rotation = shot.Item3 * bulletSpawn.rotation;
            shot.Item1.SetActive(true);
        }
    }
    
    public void ShotLevel(float graze) {
        if (_shotLevel == _shots.Length - 1)
            return;
        for (var i = 0; i < upgradeGraze.Length; i++) {
            if (Math.Abs(graze - upgradeGraze[i]) > 0.5) continue;
                Debug.Log("Upgrade");
                _shotLevel = i + 1;
                poolLevels[i].SetActive(false);
                poolLevels[i + 1].SetActive(true);
                
        }
    }
}
