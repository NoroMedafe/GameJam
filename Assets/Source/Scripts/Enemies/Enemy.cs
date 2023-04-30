using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private EnemyBullet _bullet;
    [SerializeField] private float _shootStrength;
    [SerializeField] private float _shotDelay;

    private List<Vector2[]> _shotDirections = new List<Vector2[]>();
    private int _currentShotDirection = 0;

    private float _lastShotTime;

    private List<EnemyBullet> _bullets = new();
    private Coroutine _coroutine;

    private void Start()
    {
        _shotDirections.Add(new Vector2[]{
            Vector2.up,
            Vector2.right,
            Vector2.down,
            Vector2.left
        });

        _shotDirections.Add(new Vector2[]{
            Vector2.up + Vector2.right,
            Vector2.right + Vector2.down,
            Vector2.down + Vector2.left,
            Vector2.left + Vector2.up
        });
    }

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

        foreach (Vector2 direction in _shotDirections[_currentShotDirection])
        {
            EnemyBullet bullet = Instantiate(_bullet, (Vector2)transform.position + direction, Quaternion.identity);
            bullet.Shoot(transform.position, _shootStrength);
        }

        _currentShotDirection++;
        if (_currentShotDirection == _shotDirections.Count)
        {
            _currentShotDirection = 0;
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
