using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BossHealthBarControl : MonoBehaviour {
    
    private SliderHealthBar _healthBar;
    
    private void Start() {
        _healthBar = FindObjectOfType<SliderHealthBar>(true);
        _healthBar.gameObject.SetActive(true);
        _healthBar.enemy = GetComponent<Health>();
    }

    private void OnDestroy() {
        _healthBar.enemy = null;
        _healthBar.gameObject.SetActive(false);
    }
}
