using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _lifetime;
    private float _borntime;

    private bool _isShoot = false;

    private void Start()
    {
        _borntime = Time.time;
    }
    public void Shoot(Vector2 person, float Force)
    {

        var heading = (person - (Vector2)transform.position);
        var distance = heading.magnitude;
        var direction = heading / distance * -1;

        Vector2 jeck = direction * Force;
        _rigidbody2D.velocity = jeck;

        //_rigidbody2D.AddForce(jeck, ForceMode2D.Impulse);
        _isShoot = true;
    }
    private void Update()
    {
        if (!_isShoot)
            return;

        if (Time.time >= _borntime + _lifetime)
        {
            Destroy(gameObject);
        }
            
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {

        }
    }
}
