using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHealthBar : MonoBehaviour{

    // [SerializeField] private Health enemy;
    [SerializeField] public GameObject healthBar;
    private Slider _healthBarSlider;
    public Health enemy;

    // TODO: Make it so that a health bar is only created when a boss is spawned & make it find for bosses with tag probably
    private void Start() {
        _healthBarSlider = (Slider) healthBar.GetComponentInChildren(typeof(Slider));
        // _healthBarSlider = GetComponent<Slider>();
    }

    private void Update(){
        // if(!enemy.Equals(null) && enemy.CurrentHealth <= 0) healthBar.SetActive(false);
        
        _healthBarSlider.value = (enemy.CurrentHealth / enemy.startingHealth) * 100;
    }
}
