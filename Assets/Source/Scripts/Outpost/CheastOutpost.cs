using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheastOutpost : Outpost
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsResourcesReady)
        {
            if (collision.gameObject.TryGetComponent(out ResourcePickup component))
            {
               ResourceData resource = component.Take();
               ReplenishmentResources(resource.Id);
            }
        }
    }
}
