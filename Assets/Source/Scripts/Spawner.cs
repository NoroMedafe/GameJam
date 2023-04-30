using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private BigEnemy _enemy;
    [SerializeField] private BoxCollider2D _collider;

    private Vector3 _randomPosition;
    private float _delay;
    private float _timer;

    void Start()
    {
        RandomizePosition();
        _delay = Random.Range(20f, 40f);
       
    }

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer>= _delay)
        {
            Instantiate(_enemy, transform.position + _randomPosition,Quaternion.identity);
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
