using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
[RequireComponent(typeof (InputSystem))]
public class Player : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField] private float _speed = 3f;

    private InputSystem _input;
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _input = GetComponent<InputSystem>();
=======
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _speed;
    private InputSystem _inputSystem;

    private void Awake()
    {
        _inputSystem = GetComponent<InputSystem>();
>>>>>>> Vitya
    }

    private void FixedUpdate()
    {
<<<<<<< HEAD
        _rigidbody.MovePosition(_rigidbody.position + _input.MoveDirection * _speed * Time.fixedDeltaTime);
=======
        _rigidbody.velocity = _inputSystem.MoveDirection * _speed;
>>>>>>> Vitya
    }
}
