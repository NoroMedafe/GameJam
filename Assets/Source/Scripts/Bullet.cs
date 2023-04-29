using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
   public void Shoot(Vector3 person, float Force)
    {

        var heading = (person - transform.position);
        var distance = heading.magnitude;
        var direction = heading / distance * -1;

        Vector3 jeck = direction * Force;
        jeck.z = 0f;
        _rigidbody2D.AddForce(jeck, ForceMode2D.Impulse);
    }
}
