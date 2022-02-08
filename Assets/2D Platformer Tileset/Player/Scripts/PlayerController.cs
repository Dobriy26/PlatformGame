using System;
using System.Collections;
using System.Collections.Generic;
using Core.Scripts.Input;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float Speed = 14f;
    public float Assel = 6f;
    public GroundChecker groundChecker;
    public float jumpForce;
    
    private Vector2 _input;
    private Rigidbody2D _rb;
    private Animator _animator;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        groundChecker = GetComponentInChildren<GroundChecker>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        var isGround = groundChecker.IsGrounded();
        _input.x = CrossPlatformInputManager.GetAxis("Horizontal");
        if(CrossPlatformInputManager.GetButtonDown("Jump") && _rb.velocity.y == 0 && isGround)
            _rb.AddForce(Vector2.up * jumpForce);
        if(Math.Abs(_input.x) > 0 && _rb.velocity.y == 0 && isGround)
            _animator.SetBool("IsRunning", true);
        else
            _animator.SetBool("IsRunning", false);

        if (_rb.velocity.y == 0 && isGround)
        {
            _animator.SetBool("IsJumping", false);
            _animator.SetBool("IsFallen", false);
        }
            
        if(_rb.velocity.y > 0)
            _animator.SetBool("IsJumping", true);

        if (_rb.velocity.y < 0)
        {
            _animator.SetBool("IsJumping", false);
            _animator.SetBool("IsFallen", true);
        }
    }

    private void FixedUpdate()
    {
        var a = Assel;
        var _xVelosity = _input.x == 0 ? 0 : _rb.velocity.x;
        _rb.AddForce(new Vector2((_input.x * Speed-_rb.velocity.x) * a, 0));
        _rb.velocity = new Vector2(_xVelosity, _rb.velocity.y);
    }
}
