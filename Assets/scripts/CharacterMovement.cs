using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float jumpForce;
    private Vector3 _input;
    private bool _isMoving;

    private bool jumping;
    private bool falling;

    private Rigidbody2D _rigidbody;

    public Animator _animator;
    public Vector3 localVel;
    private CharacterAnimations _animations;
    [SerializeField] private SpriteRenderer _characterSprite;
    private void Start()
    {   
        _rigidbody = GetComponent<Rigidbody2D>();
        _animations = GetComponentInChildren<CharacterAnimations>();
    }
    private void Update()
    {
        Move();
        
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        _input = new Vector2(Input.GetAxis("Horizontal"), 0);
        transform.position += _input * _speed * Time.deltaTime;
        _isMoving = _input.x != 0 ? true : false;
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(_rigidbody.velocity.y) < 0.05f)
        {
            _rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        if (_isMoving)
        {
            _characterSprite.flipX = _input.x > 0 ? false : true;
        }
        if (localVel.y > 0)
        {
            _animator.SetTrigger("Jump");
        }
        if (localVel.y < 0)
        {
            _animator.SetTrigger("Fall");
        }
        if (localVel.y == 0)
        {
            _animator.ResetTrigger("Jump");
            _animator.ResetTrigger("Fall");
        }
        localVel = transform.InverseTransformDirection(_rigidbody.velocity);
        _animations.IsMoving = _isMoving;
    }
}
