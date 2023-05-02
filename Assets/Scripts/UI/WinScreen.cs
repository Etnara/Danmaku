using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScreen : MonoBehaviour {
    
    private float _startingTime;
    public float timeToWait;
    
    private void Start() {
        _startingTime = Time.time;
    }

    private void Update() {
        if (Time.time > _startingTime + timeToWait && Input.anyKeyDown)
            SceneManager.LoadScene("Start Menu");
    }
}
