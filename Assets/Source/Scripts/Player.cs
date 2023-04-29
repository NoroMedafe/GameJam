using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;
    private InputSystem _inputSystem;

    private void Awake()
    {
        _inputSystem = GetComponent<InputSystem>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = _inputSystem.MoveDirection * _speed;
    }
}
