using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemDrop : MonoBehaviour {

    public GameObject[] drops;
    public GameObject health;
    public float healthChance;
    
    private void OnDestroy() {
        // Guaranteed Drops
        // TODO: Make it so that the drops are spawned in a circle around the object
        // Probably add a check for the amount of items and use presets
        foreach (var c in drops)
            Instantiate(c);
        // Percent Chance for Health
        if (Random.Range(0, 100) <= healthChance)
            Instantiate(health, transform.position, new Quaternion(0, 0 , 180, 0));
    }
}
