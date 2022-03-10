using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField]
    private float directForce;
    [SerializeField]
    private float turForce;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(0, 0, directForce * Time.fixedTime);
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