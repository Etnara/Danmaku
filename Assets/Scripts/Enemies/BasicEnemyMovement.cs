using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyMovement : MonoBehaviour{

    public Transform[] Waypoints;
    public int curWaypoint;
    public float Speed;
    public bool patrol = true;
    public Vector2 Target;
    public Vector2 MoveDirection;
    public Vector2 Velocity;

    void FixedUpdate(){

        if (curWaypoint < Waypoints.Length){

            Target = Waypoints[curWaypoint].position;
            MoveDirection = Target - (Vector2) transform.position;
            Velocity = GetComponent<Rigidbody2D>().velocity;

            if (MoveDirection.magnitude < 1)
                curWaypoint++;
            else
                Velocity = MoveDirection.normalized * Speed;
            //Debug.Log("Target = " + Target + "\nMove Direction = " + MoveDirection + "\nVelocity = " + Velocity);
         
        }
        else{
            if (patrol)
                curWaypoint = 0;
            else
                Velocity = Vector3.zero;
        }
        GetComponent<Rigidbody2D>().velocity = Velocity;
        transform.Rotate(new Vector3(0, 0, 180) * Time.deltaTime);
    }
}
