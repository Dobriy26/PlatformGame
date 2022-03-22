using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField]
    private float directForce = 0;
    [SerializeField]
    private float turForce;
    [SerializeField] 
    private float maxSpeed;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(0, 0, directForce * Time.fixedTime);
        var velocity = _rigidbody.velocity;
        _rigidbody.velocity = new Vector3(velocity.x, velocity.y,
            Math.Min(velocity.z, maxSpeed));
        if (Input.GetKey(KeyCode.D))
        {
            _rigidbody.AddForce(turForce,0,0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _rigidbody.AddForce(-turForce,0,0);
        }
    }
}