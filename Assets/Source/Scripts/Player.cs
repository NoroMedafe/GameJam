using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
[RequireComponent(typeof (InputSystem))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    private InputSystem _input;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _input = GetComponent<InputSystem>();
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_rigidbody.position + _input.MoveDirection * _speed * Time.fixedDeltaTime);
    }
}
