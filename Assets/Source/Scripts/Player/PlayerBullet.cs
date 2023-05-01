using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _lifetime = 1.2f;
    private float _time = 0f;

    private void Update()
    {
        _time += Time.deltaTime;
        if (_time >= _lifetime)
        {
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out BigEnemy enemy))
        {
            enemy.TakeDamage(_damage);
        }

        Destroy(gameObject);
    }
}
