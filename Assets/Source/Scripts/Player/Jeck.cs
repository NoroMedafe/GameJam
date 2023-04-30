using UnityEngine;

[RequireComponent(typeof(Player))]
public class Jeck : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _jeckForce;
    [SerializeField] private InputSystem _inputSystem;
    [SerializeField] private TrailRenderer _trail;
    [SerializeField] private float _jeckStunDuration;
    private Player _player;

    private bool _isFirstDashInSequence = true;
    private bool _isJecking;
    private bool _isJeckSequenceStoped;
    private float _jeckStunTime;

    [Tooltip("����� ������ ����")][SerializeField] private float _jeckDuration;
    [Tooltip("����� �� ���������� ����")][SerializeField] private float _jeckCooldown;
    private float _lastJeck;
    public bool IsJecking => _isJecking;
    private Vector2 _jeckDirection;

    public Vector2 JeckVelocityBonus => _isJecking ? _jeckDirection * _jeckForce : Vector2.zero;

    private void Start()
    {
        _player = GetComponent<Player>();
    }


    private void Update()
    {
        if (_isJeckSequenceStoped)
        {
            _jeckStunTime += Time.deltaTime;
            if (_jeckStunTime >= _jeckStunDuration)
            {
                _isJeckSequenceStoped = false;
                _isFirstDashInSequence = true;
            }
        }

        if (_isJecking && Time.time >= _lastJeck + _jeckDuration)
        {
            _trail.enabled = false;
            _isJecking = false;
            _isJeckSequenceStoped = true;
            _jeckStunTime = 0f;
        }


        if (!Input.GetKeyDown(KeyCode.Space))
            return;

        if (_isJeckSequenceStoped)
            return;

        if (Time.time < _lastJeck + _jeckCooldown)
        {
            _isJeckSequenceStoped = true;
            return;
        }


        if (_isFirstDashInSequence)
        {
            _player.LoseStaminaForDash();
            _isFirstDashInSequence = false;

            if (!_player.IsDashAble())
                return;
        }

        _lastJeck = Time.time;
        _jeckDirection = _inputSystem.GetCursorDirection(transform).normalized;
        _isJecking = true;
        _trail.enabled = true;

    }
}