using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBombs : MonoBehaviour{

    public float startingBombs;
    public float currentBombs { get; private set; }

    public GameObject bombObj;
    public Player Player;

    public float shotRate;
    float nextShot;
    float originalSpeed;
    public float speedChange;
    Vector3 originalScale;
    public Vector3 scaleChange;

    public bool dbble { get; private set; }

    void Awake()
    {
        currentBombs = startingBombs;
        originalSpeed = Player.speed;
        originalScale = bombObj.transform.localScale;
    }

    void FixedUpdate(){

        if (Time.time > nextShot){

            bombObj.SetActive(false);
            Player.speed = originalSpeed;
            bombObj.transform.localScale = originalScale;

            if (Input.GetKey("x") && currentBombs > 0)
            {
                nextShot = Time.time + shotRate;
                bombObj.SetActive(true);
                currentBombs--;
                dbble = true;
                

            }
            return;
        }
        bombObj.transform.localScale += scaleChange;
        Player.speed -= speedChange;
        dbble = false;
    }

}
