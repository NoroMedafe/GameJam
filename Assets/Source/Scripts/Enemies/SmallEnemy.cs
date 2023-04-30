using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallEnemy : Enemy
{
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;

    private float _currentDelay;
    private bool _isReadyAttack;
    private void Update()
    {
        _currentDelay += Time.deltaTime;
        if (_delay <= _currentDelay)
        {
            _currentDelay = 0;
            _isReadyAttack = true;
        }
    }
    public override void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.TakeDamage(_damage);
            _isReadyAttack = false;
        }
    }


}
