using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrazeCounter : MonoBehaviour{

    public Text MyText;
    public Graze player;

    // Update is called once per frame
    void Update()
    {
        
        MyText.text = "Graze: " + player.graze;

    }
}
