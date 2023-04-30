using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bullet;
    [SerializeField] private float _bulletForce = 20f;
    [SerializeField] private InputSystem _inputSystem;
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 direction = _inputSystem.GetCursorDirection(transform);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            transform.rotation =Quaternion.Euler(0f,0f ,angle);
            Shoot();
        }
    }
    private void Shoot()
    {
        GameObject bullet = Instantiate(_bullet, _firePoint.position, _firePoint.rotation);
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
        rigidbody.AddForce(_firePoint.up * _bulletForce, ForceMode2D.Impulse);
    }
}
