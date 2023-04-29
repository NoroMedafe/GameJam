using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Jeck : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _jeckForce;
    [SerializeField] private Camera _mainCamera;
   
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);

            var heading = (mousePos - transform.position);
            var distance = heading.magnitude;
            var direction = heading / distance;

            Vector3 jeck = direction * _jeckForce;

            jeck.z = 0f;
            _rigidbody.AddForce(jeck, ForceMode2D.Impulse);
        }
    }
}
