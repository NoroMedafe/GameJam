using UnityEngine;

public class PlayerPickZone : MonoBehaviour
{

    [SerializeField] private float _radius;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            a_ResourceSource resourceSource = null;
            foreach (Collider2D collider in Physics2D.OverlapCircleAll(transform.position, _radius))
            {
                if (!collider.TryGetComponent(out resourceSource))
                    return;
            }
            resourceSource?.Take();            
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}