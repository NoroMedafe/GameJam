using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(InputSystem))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;

    private float _maxHealth = 100;
    private float _minHealth = 0;
    private float _currentHealth;

    private InputSystem _input;
    private Rigidbody2D _rigidbody;

    public event Action<float> ChangedHealth;

    public float Health => _maxHealth;
    private float CurrentHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = Mathf.Clamp(value, _minHealth, _maxHealth); }
    }

    private void Start()
    {
        CurrentHealth = _maxHealth;

        _rigidbody = GetComponent<Rigidbody2D>();
        _input = GetComponent<InputSystem>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _input.MoveDirection * _speed;
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        ChangedHealth?.Invoke(CurrentHealth);
    }
}
