using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Jeck : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _jeckForce;
    [SerializeField] private InputSystem _inputSystem;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           
            Vector3 jeck = _inputSystem.GetCursorDirection(transform) * _jeckForce;

            jeck.z = 0f;
            _rigidbody.AddForce(jeck, ForceMode2D.Impulse);
        }
    }
}
