using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private EnemyBullet _bullet;
    [SerializeField] private int _countBullet;

    private List<EnemyBullet> _bullets = new();
    private Coroutine _coroutine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(Shot());
            }
            else
            {
                StopCoroutine(_coroutine);
               _coroutine = StartCoroutine(Shot());
            }
        }
    }
    private IEnumerator Shot()
    {
        for (int i = 0; i < _countBullet; i++)
        {
            _bullets.Add(Instantiate(_bullet, transform.position + Vector3.up, Quaternion.identity));
            _bullets.Add(Instantiate(_bullet, transform.position + Vector3.down, Quaternion.identity));
            _bullets.Add(Instantiate(_bullet, transform.position + Vector3.left, Quaternion.identity));
            _bullets.Add(Instantiate(_bullet, transform.position + Vector3.right, Quaternion.identity));
        }
        int index = 0;
        for (int i = 0; i < _countBullet; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                _bullets[index].Shoot(transform.position, 30);
                index++;
            }
            yield return new WaitForSeconds(1);
        }
        _bullets.Clear();
        _coroutine = null;
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
