using UnityEngine;
using Jam.Player;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private BoxCollider2D _collider;
    [SerializeField] private Transform _player;

    private Vector3 _randomPosition;
    private float _delay;
    private float _timer;

    void Start()
    {
        RandomizePosition();
        _delay = Random.Range(10f, 20f);

    }

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _delay)
        {
            Enemy enemy = Instantiate(_enemy, transform.position + _randomPosition, Quaternion.identity);
            if (enemy.TryGetComponent(out SmallEnemy smallEnemy))
            {
                smallEnemy.SetTarget(_player);
            }
            _timer = 0;
            RandomizePosition();
        }

    }

    private void RandomizePosition()
    {
        _randomPosition = new Vector3(
        Random.Range(0, _collider.size.x),
        Random.Range(0, _collider.size.y),
        0
        );
    }
}
