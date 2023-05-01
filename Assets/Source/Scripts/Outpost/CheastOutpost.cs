using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheastOutpost : MonoBehaviour
{
    [SerializeField] private Outpost outpost;
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.TryGetComponent(out ResourcePickup component))
            {
                 ResourceData resource = component.Take();
                outpost.ReplenishmentResources(resource.Id);
            }
    }
}
