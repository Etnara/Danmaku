using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;

[System.Serializable]
public class SpawnerElement {
    public GameObject prefab;
    public int time;
    public Vector3 offset;
    public Vector3 bodyOffset;
    public bool mirror;
}

public class EnemySpawner : MonoBehaviour {

    private float _time;
    private float _startTime;
    public int currentEnemies;

    public SpawnerElement[] spawns;

    private void Start() {
        // Debug.Log("Starting");
        currentEnemies = 0;
        _startTime = Time.time;
        StartCoroutine(Spawn());
    }
    
    private IEnumerator Spawn() {
        var i = 0;
        while (i < spawns.Length) { 
            if (spawns[i].time == -1) {
                while (currentEnemies > 0) {
                    // Debug.Log("Waiting for " + currentEnemies + " enemies to die");
                    yield return null;
                }
                yield return new WaitForSeconds(3);
                
                var tmp = Instantiate(spawns[i].prefab, transform.position + spawns[i].offset, Quaternion.identity);
                tmp.transform.Find("Body").position += spawns[i].bodyOffset;
                
                if (spawns[i].mirror) {
                    var tmpTransformScale = tmp.transform.localScale;
                    tmpTransformScale = new Vector3(-tmpTransformScale.x, tmpTransformScale.y, tmpTransformScale.z);
                    tmp.transform.localScale = tmpTransformScale;
                }
                
                currentEnemies++;
                while (currentEnemies > 0) {
                    // Debug.Log("Waiting for boss to die: " + currentEnemies + " enemies to die");
                    yield return null;
                }
                i++;
                _startTime = Time.time;
                continue;
            }
            
            _time = Time.time - _startTime;
            if (_time >= spawns[i].time) {
                // Instantiate(spawns[i].prefab, transform.position + spawns[i].offset, Quaternion.identity);
                
                var tmp = Instantiate(spawns[i].prefab, transform.position + spawns[i].offset, Quaternion.identity);
                tmp.transform.Find("Body").position += spawns[i].bodyOffset;
                
                if (spawns[i].mirror) {
                    var tmpTransformScale = tmp.transform.localScale;
                    tmpTransformScale = new Vector3(-tmpTransformScale.x, tmpTransformScale.y, tmpTransformScale.z);
                    tmp.transform.localScale = tmpTransformScale;
                }

                currentEnemies++;
                i++;
            }
            // Debug.Log(currentEnemies);
            yield return null;
        }

        while (currentEnemies > 0) {
            // Debug.Log(currentEnemies);
            yield return null;
        }

        yield return new WaitForSecondsRealtime(3);
        gameObject.SetActive(false);
    }

    private void OnDisable() {
        // Debug.Log("Spawner Disabled");
        if(!this.gameObject.scene.isLoaded) return;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
