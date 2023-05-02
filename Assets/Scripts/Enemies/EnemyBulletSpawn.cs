using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

public class EnemyBulletSpawn : MonoBehaviour{

    public GameObject Shots;
    public Transform[] BulletSpawn;
    private float _nextShot;
    public float shotRate;
    
    public ObjectPool objectPool;

    public void Start() {
        var parent = FindObjectsOfType<GameObject>().FirstOrDefault(x => x.name == "Pools");
        // objectPool = FindObjectsOfType<ObjectPool>().FirstOrDefault(x => x.gameObject.name == Shots.name);
        // objectPool = parent.GetComponentsInChildren<ObjectPool>().FirstOrDefault(x => x.gameObject.name == Shots.name);
        objectPool = FindObjectsOfType<ObjectPool>(true).FirstOrDefault(x => x.gameObject.name == Shots.name);
        // Debug.Log("Looking for " + Shots.name + " in " + parent.name);
        // Debug.Log("objectPool = " + objectPool);
        if (objectPool == null) {
            var obj = new GameObject();
            obj.name = Shots.name;
            obj.transform.parent = parent.transform;
            objectPool = obj.AddComponent<ObjectPool>();
            objectPool.objectToPool = Shots;
        } else if (!objectPool.gameObject.activeSelf)
            objectPool.gameObject.SetActive(true);

        objectPool.currentlyUsing++;
        // Debug.Log(objectPool.name);
    }
    
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

    private void OnDestroy() { 
        // Call DisablePool() on the object's ObjectPool component
        objectPool.currentlyUsing--;
        if (objectPool!= null)
            objectPool.DisablePoolStart();
        // objectPool.SetActive(false);
    }
}
