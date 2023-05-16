using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ExplodingEnemy : MonoBehaviour {
    
    public GameObject Shots;
    public Transform[] BulletSpawn;
    private float _nextShot;
    public ObjectPool objectPool;

    public void Start() {
        var parent = FindObjectsOfType<GameObject>().FirstOrDefault(x => x.name == "Pools");
        objectPool = FindObjectsOfType<ObjectPool>(true).FirstOrDefault(x => x.gameObject.name == Shots.name);
        if (objectPool == null) {
            var obj = new GameObject();
            obj.name = Shots.name;
            obj.transform.parent = parent.transform;
            objectPool = obj.AddComponent<ObjectPool>();
            objectPool.objectToPool = Shots;
        } else if (!objectPool.gameObject.activeSelf)
            objectPool.gameObject.SetActive(true);

        objectPool.currentlyUsing++;
    }
    
    public void Explode() { 
        foreach (var pos in BulletSpawn) { 
            var shot = objectPool.GetPooledObject();
            shot.Item1.transform.position = shot.Item2 + pos.position; 
            shot.Item1.transform.rotation = shot.Item3 * pos.rotation;
            shot.Item1.SetActive(true); 
        }

        Destroy(gameObject);
    }

    private void OnDestroy() { 
        // Call DisablePool() on the object's ObjectPool component
        objectPool.currentlyUsing--;
        if (objectPool!= null)
            objectPool.DisablePoolStart();
        // objectPool.SetActive(false);
    } 

}
