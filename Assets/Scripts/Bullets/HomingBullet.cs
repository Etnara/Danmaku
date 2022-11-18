using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class HomingBullet : MonoBehaviour {

    private Transform _target;
    private Rigidbody2D _rb;
    
    public float speed;
    public float rotateSpeed;

    private void Start() {
        _target = FindClosestEnemy() == null ? null: FindClosestEnemy().transform;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        _rb.velocity = transform.up * speed;

        if (!_target) {
            _rb.angularVelocity = 0;
            return; 
        }
        
        Vector2 direction = (Vector2)_target.position - _rb.position;
        
        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.up).z;
        _rb.angularVelocity = -rotateAmount * rotateSpeed;
    }

    private GameObject FindClosestEnemy() {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos) {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance) {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
