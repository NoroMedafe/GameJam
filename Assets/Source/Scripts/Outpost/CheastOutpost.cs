using UnityEngine;

public class CheastOutpost : Outpost
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered");

        if (!IsResourcesReady)
            return;

        Debug.Log("Resource is ready");


        if (collision.gameObject.TryGetComponent(out ResourcePickup component))
        {
            Debug.Log("Resource is got");
            ResourceData resource = component.Take();
            ReplenishmentResources(resource.Id);
        }

    }
}
