using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemPickup : MonoBehaviour {
    
    private Transform _target;
    private Transform _pos;
    private Rigidbody2D _rb;
    
    public float defaultSpeed;
    public float defaultRotateSpeed;
    public float defaultRange;
    
    private float _speed;
    private float _rotateSpeed;
    private float _range;

    public bool collect;

    private void Start() {
        _target = GameObject.FindGameObjectWithTag("Player") == null ? null: GameObject.FindGameObjectWithTag("Player").transform;
        _rb = GetComponent<Rigidbody2D>();
        _pos = GetComponent<Transform>();
        
        collect = false;
        
        _speed = defaultSpeed;
        _rotateSpeed = defaultRotateSpeed;
        _range = defaultRange;
    }
    
    private void FixedUpdate() {
        var up = transform.up;
        
        // If in Collection Zone, permanently update Speed, RotateSpeed, and Range
        if (collect) { 
            _speed = 5; 
            _rotateSpeed = 5000; 
            _range = 500;
        }

        if (!_target || Vector2.Distance(_pos.position, _target.position) > _range) {
            _rb.velocity = up * _speed;
            _rb.angularVelocity = 0;
            return; 
        }

        var direction = ((Vector2)_target.position - _rb.position).normalized;
        var rotateAmount = Vector3.Cross(direction, up).z;

        _rb.velocity = up * (_speed * 2);
        _rb.angularVelocity = -rotateAmount * _rotateSpeed;
    }
}
