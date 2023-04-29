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
    private float _minStamina = 0;
    private float _maxStamina = 100;
    private float _currenStamina;

    private InputSystem _input;
    private Rigidbody2D _rigidbody;

    public event Action<float> ChangedHealth;
    public event Action<float> ChangedStamina;

    public float Health => _maxHealth;
    public float Stamina => _maxStamina;

    private void Start()
    {
        CurrentHealth = _maxHealth;
        CurrentStamina = _maxStamina;

        _rigidbody = GetComponent<Rigidbody2D>();
        _input = GetComponent<InputSystem>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _input.MoveDirection * _speed;
    }

    private float CurrentHealth
    {
        get => _currentHealth;
        set => _currentHealth = Mathf.Clamp(value, _minHealth, _maxHealth);
    }
    
    private float CurrentStamina
    {
        get => _currenStamina;
        set => _currenStamina = Mathf.Clamp(value, _minHealth, _maxStamina);
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        ChangedHealth?.Invoke(CurrentHealth);
    }

    public void LoseStamina(float amount)
    {
        CurrentStamina -= amount;
        ChangedStamina?.Invoke(CurrentStamina);
    }

    public void MakeDAsh()
    {
        LoseStamina(33.33f);
    }
}
