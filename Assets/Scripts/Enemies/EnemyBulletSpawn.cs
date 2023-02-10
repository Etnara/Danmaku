using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawn : MonoBehaviour{

    public GameObject Shots;
    public Transform[] BulletSpawn;
    private float _nextShot;
    public float shotRate;
    
    public ObjectPool objectPool;

    private void FixedUpdate() {
        
        if (Time.time <= _nextShot) return;
        _nextShot = Time.time + shotRate;
        
        foreach (var pos in BulletSpawn) {
            var shot = objectPool.GetPooledObject();
            shot.Item1.transform.position = shot.Item2 + pos.position; 
            shot.Item1.transform.rotation = shot.Item3 * pos.rotation;
            shot.Item1.SetActive(true);
        }
    }
}
