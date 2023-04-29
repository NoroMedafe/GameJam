using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private EnemyBullet _bullet;
    [SerializeField] private float _shootStrength;
    [SerializeField] private float _shotDelay;

    private float _lastShotTime;

    private List<EnemyBullet> _bullets = new();
    private Coroutine _coroutine;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            if (_lastShotTime + _shotDelay <= Time.time)
            {
                _lastShotTime = Time.time;
                Shot();
            }
        }
    }
    private void Shot()
    {
        Vector3[] directionsArray =
        {
            Vector3.up,
            Vector3.right,
            Vector3.down,
            Vector3.left
        };

        foreach (Vector3 direction in directionsArray)
        {
            EnemyBullet bullet = Instantiate(_bullet, transform.position + direction, Quaternion.identity);
            bullet.Shoot(transform.position, _shootStrength);
        }

    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health<=0)
        {
            Destroy(gameObject);
        }
    }

}
