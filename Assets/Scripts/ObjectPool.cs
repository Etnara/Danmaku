using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour {
    
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    private Vector3 _offset;
    private Quaternion _rotation;
    
    private void Start() {
        pooledObjects = new List<GameObject>();
        _offset = objectToPool.transform.position;
        _rotation = objectToPool.transform.rotation;
        // Temp code to test the pool
        // GameObject tmp;
        // for(int i = 0; i < 1; i++) {
        //     tmp = Instantiate(objectToPool);
        //     tmp.SetActive(false);
        //     pooledObjects.Add(tmp);
        // }
    }
   public Tuple<GameObject, Vector3, Quaternion> GetPooledObject() {
        // Pull from the list of pooled objects_
        foreach (var obj in pooledObjects.Where(obj => !obj.activeInHierarchy)) {
            // Debug.Log("Pulled from pool");
            return new Tuple<GameObject, Vector3, Quaternion>(obj, _offset, _rotation);
        }

        // If there are no objects in the pool, create a new one
        // Debug.Log("Created new object");
        var newObj = Instantiate(objectToPool,this.transform);
        newObj.SetActive(false);
        pooledObjects.Add(newObj);
        return new Tuple<GameObject, Vector3, Quaternion>(newObj, _offset, _rotation);
    }

   private IEnumerator DisablePool() {
       // Debug.Log("Disabling Pool");
       // Repeatedly remove objects from the pool until there are none left
       while (pooledObjects.Count > 0)
           for (var i = 0; i < pooledObjects.Count; i++) {
               if (!pooledObjects[i].activeInHierarchy) { 
                   // Debug.Log("test"); 
                   Destroy(pooledObjects[i]);
                   pooledObjects.Remove(pooledObjects[i]);
                   i--;
               }
               yield return null;
           }
       gameObject.SetActive(false);
       // StopCoroutine(DisablePool()); // Already called by Unity
   }
   
   public void DisablePoolStart() {
       StartCoroutine(DisablePool());
   }
   
   private void OnDisable() {
       // Debug.Log("OnDisable");
       if (transform.parent.name == "Pools") return;
       
       if (transform.parent.GetComponentsInChildren<Transform>().GetLength(0) <= 1)
           transform.parent.gameObject.SetActive(false);
   }
}
