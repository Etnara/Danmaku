using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHealthBar : MonoBehaviour{

    [SerializeField] private Health enemy;
    [SerializeField] public GameObject healthBar;

    // Update is called once per frame
    void Update(){
        if(enemy.currentHealth > 0)
            (healthBar.GetComponentInChildren(typeof(Slider)) as Slider).value = (enemy.currentHealth / enemy.startingHealth) * 100;
        else
            healthBar.SetActive(false);
    }
}
