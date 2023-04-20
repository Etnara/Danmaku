using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class ObjectPool : MonoBehaviour {
    
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    private Vector3 _offset;
    private Quaternion _rotation;
    public int currentlyUsing;
    
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

   public void DisablePoolStart() {
       if (currentlyUsing > 0) Debug.Log("Currently using: " + currentlyUsing);
       if (currentlyUsing > 0) return;
       StartCoroutine(DisablePool());
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
       // Debug.Log(gameObject.name + " Disabled");
       gameObject.SetActive(false);
       // StopCoroutine(DisablePool()); // Already called by Unity
   }
   
   private void OnDisable() {
       // Debug.Log("OnDisable");
       // Don't call if resetting the scene
       if(!this.gameObject.scene.isLoaded) return;
       if (transform.parent.name == "Pools") return;
       // if (!transform.parent.gameObject.activeSelf) return;
       transform.parent.GetComponent<ParentPool>().DisableParent();
       
       // if (transform.parent.GetComponentsInChildren<Transform>().GetLength(0) <= 1)
       //     transform.parent.gameObject.SetActive(false);
   }
}
