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

    private void OnEnable() {
        _target = FindClosestEnemy() == null ? null: FindClosestEnemy().transform;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() {
        _rb.velocity = transform.up * speed;

        if (!_target) {
            _rb.angularVelocity = 0;
            return; 
        }
        
        var direction = ((Vector2)_target.position - _rb.position).normalized;
        var rotateAmount = Vector3.Cross(direction, transform.up).z;
        
        _rb.angularVelocity = -rotateAmount * rotateSpeed;
    }

    private GameObject FindClosestEnemy() {
        var gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        
        var distance = Mathf.Infinity;
        var position = transform.position;
        
        foreach (var go in gos) {
            var curDistance = (go.transform.position - position).sqrMagnitude;
            if (curDistance >= distance)
                continue;
            
            closest = go;
            distance = curDistance;
        }
        
        return closest;
    }
}
