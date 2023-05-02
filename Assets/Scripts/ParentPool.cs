using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentPool : MonoBehaviour {
    
    public bool CoroutineRunning { get; private set; }
    
    public void DisableParent() {
        if (CoroutineRunning) return;
        StartCoroutine(DisableParentCoroutine());
    }
    
    private IEnumerator DisableParentCoroutine() {
        CoroutineRunning = true;
        while (true) {
            if (GetComponentsInChildren<Transform>().GetLength(0) <= 1) {
                // Debug.Log(gameObject.name + " is empty, disabling");
                CoroutineRunning = false;
                gameObject.SetActive(false);
                yield break;
            }
            yield return null;
        }
    }
}
