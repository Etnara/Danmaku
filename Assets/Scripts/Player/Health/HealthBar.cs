﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour{

    [SerializeField] private PlayerHealth Player;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

    // Start is called before the first frame update
    void Start(){
        totalHealthBar.fillAmount = Player.currentHealth / 10;
    }

    // Update is called once per frame
    void Update(){
        currentHealthBar.fillAmount = Player.currentHealth / 10;
    }
}
