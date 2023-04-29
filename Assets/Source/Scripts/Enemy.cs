using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Bullet _bullet;
    [SerializeField] private int _countBullet;

    private List<Bullet> _bullets = new();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            StartCoroutine(Shot());
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
    }


}
