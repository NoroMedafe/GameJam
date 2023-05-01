using Jam.Player;
using Pathfinding;
using UnityEngine;

public class SmallEnemy : Enemy
{
    [SerializeField] private int _health;
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;

    public AIDestinationSetter ai;
    private float _currentDelay;
    private bool _isReadyAttack;


    public void SetTarget(Transform transform)
    {
        ai.target = transform;
    }


    private void Update()
    {
        if (!_isReadyAttack)
        {
            _currentDelay += Time.deltaTime;
            if (_delay <= _currentDelay)
            {
                _currentDelay = 0;
                _isReadyAttack = true;
            }
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
            if (_isReadyAttack)
            {
                player.TakeDamage(_damage);
                _isReadyAttack = false;
            }
            
        }
    }
}
