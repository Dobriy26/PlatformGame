using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 14f;
    public float Assel = 6f;

    private Vector2 _input;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        _input.x = Input.GetAxis("Horizontal");
        _input.y = Input.GetAxis("Jump");
    }

    private void FixedUpdate()
    {
        var a = Assel;
        var _xVelosity = _input.x == 0 ? 0 : _rb.velocity.x;
        _rb.AddForce(new Vector2((_input.x * Speed-_rb.velocity.x) * a, 0));
        _rb.velocity = new Vector2(_xVelosity, _rb.velocity.y);
    }
}
