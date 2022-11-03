using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingBullet : MonoBehaviour
{

    public Transform target;

    public float speed;
    public float rotateSpeed;

    private Rigidbody2D rb;
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        
        Vector2 direction = (Vector2)target.position - rb.position;
        
        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = -rotateAmount * rotateSpeed;
        
        Debug.Log(-rotateAmount * rotateSpeed);
        Debug.Log(rb.angularVelocity);
        rb.velocity = transform.up * speed;
    }
}
