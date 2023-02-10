using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHealthBar : MonoBehaviour{

    [SerializeField] private Health enemy;
    [SerializeField] public GameObject healthBar;
    private Slider _healthBarSlider;

    private void Start() {
        _healthBarSlider = (Slider) healthBar.GetComponentInChildren(typeof(Slider));
    }

    private void Update(){
        if(enemy.CurrentHealth <= 0) healthBar.SetActive(false);
        
        _healthBarSlider.value = (enemy.CurrentHealth / enemy.startingHealth) * 100;
    }
}
