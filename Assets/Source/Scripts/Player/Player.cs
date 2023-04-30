using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(InputSystem))]
[RequireComponent(typeof(Jeck))]
public class Player : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    [SerializeField] private float _staminaRegenSpeed;

    [SerializeField] private AudioSource _stepsAudioSource;
    [SerializeField] private AudioRandomizer _sandStepSounds;

    private float _maxHealth = 100;
    private float _minHealth = 0;
    private float _currentHealth;
    private float _minStamina = 0;
    private float _maxStamina = 100;
    private float _currenStamina;

    private InputSystem _input;
    private Rigidbody2D _rigidbody;
    private Jeck _jeck;

    public event Action<float> ChangedHealth;
    public event Action<float> ChangedStamina;

    public float Health => _maxHealth;
    public float Stamina => _maxStamina;

    private bool _isMoving;

    private void Start()
    {
        CurrentHealth = _maxHealth;
        CurrentStamina = _maxStamina;

        _rigidbody = GetComponent<Rigidbody2D>();
        _input = GetComponent<InputSystem>();
        _jeck = GetComponent<Jeck>();
    }

    private void FixedUpdate()
    {

        if (_isMoving)
        {
            if (!_stepsAudioSource.isPlaying)
            {
                _stepsAudioSource.clip = _sandStepSounds.PickRandom();
                _stepsAudioSource.Play();
            }
        }    

        if (CurrentStamina < 100)
        {
            CurrentStamina += _staminaRegenSpeed * Time.fixedDeltaTime;
            ChangedStamina?.Invoke(CurrentStamina);
        }


        if (!_jeck.IsJecking)
        {
            _rigidbody.velocity = _speed * _input.MoveDirection;
            if (_rigidbody.velocity.magnitude != 0)
            {
                _isMoving = true;
                
            }
            else
            {
                _isMoving = false;
            }
        }
        else
        {
            _rigidbody.velocity = _jeck.JeckVelocityBonus;
            _isMoving = false;
        }
    }

    private float CurrentHealth
    {
        get => _currentHealth;
        set => _currentHealth = Mathf.Clamp(value, _minHealth, _maxHealth);
    }

    private float CurrentStamina
    {
        get => _currenStamina;
        set => _currenStamina = Mathf.Clamp(value, _minStamina, _maxStamina);
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        ChangedHealth?.Invoke(CurrentHealth);
    }

    public bool IsDashAble()
    {
        if (CurrentStamina >= 100 / 3f)
            return true;
        return false;
    }

    private void LoseStamina(float amount)
    {
        CurrentStamina -= amount;
        ChangedStamina?.Invoke(CurrentStamina);
    }

    public void LoseStaminaForDash()
    {
        LoseStamina(100 / 3f);
    }
}