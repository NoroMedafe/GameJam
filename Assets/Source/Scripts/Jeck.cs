using UnityEngine;

public class Jeck : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _jeckForce;
    [SerializeField] private InputSystem _inputSystem;
    [SerializeField] private TrailRenderer _trail;

    [Tooltip("Время самого дэша")][SerializeField] private float _jeckDuration;
    [Tooltip("Время до следующего дэша")][SerializeField] private float _jeckCooldown;
    private float _lastJeck;
    private bool _isJecking;
    public bool IsJecking => _isJecking;
    private Vector2 _jeckDirection;

    public Vector2 JeckVelocityBonus => _isJecking ? _jeckDirection * _jeckForce : Vector2.zero;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.time >= _lastJeck + _jeckCooldown)
            {
                _lastJeck = Time.time;
                _jeckDirection = _inputSystem.GetCursorDirection(transform).normalized;
                _isJecking = true;
                _trail.enabled = true;
            }

        }

        if (Time.time >= _lastJeck + _jeckDuration)
        {
            _trail.enabled = false;
            _isJecking = false;
        }
    }
}