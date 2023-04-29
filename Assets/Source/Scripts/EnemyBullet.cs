using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;

    private bool _isShoot = false;
   public void Shoot(Vector3 person, float Force)
    {

        var heading = (person - transform.position);
        var distance = heading.magnitude;
        var direction = heading / distance * -1;

        Vector3 jeck = direction * Force;
        jeck.z = 0f;
        _rigidbody2D.AddForce(jeck, ForceMode2D.Impulse);
        _isShoot = true;
    }
    private void Update()
    {
        if (_isShoot)
        {
            if (_rigidbody2D.velocity.magnitude == 0)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {

        }
    }
}
