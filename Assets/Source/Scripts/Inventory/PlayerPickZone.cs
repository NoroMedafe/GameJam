using UnityEngine;

public class PlayerPickZone : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private Inventory _inventory;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            IPickable resourceSource = null;
            foreach (Collider2D collider in Physics2D.OverlapCircleAll(transform.position, _radius))
            {
                if (collider.TryGetComponent(out resourceSource))
                {
                    break;
                }
            }
            if (resourceSource == null)
                return;


            if (_inventory.CanTake())
            {
                _inventory.PutItem(resourceSource?.Take());
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}