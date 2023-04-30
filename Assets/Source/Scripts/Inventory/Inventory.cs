using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private InventorySlot[] _items = new InventorySlot[MAX_ITEM_COUNT];
    [SerializeField] private ResourcePickup _pickupPrefab;
    private Player _player;

    private const int MAX_ITEM_COUNT = 2;


    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            RemoveItem(0);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            RemoveItem(1);
        }
    }

    public bool CanTake()
    {
        for (int i = 0; i < MAX_ITEM_COUNT; i++)
        {
            if (!_items[i].IsFilled)
                return true;
        }
        return false;
    }

    public void PutItem(ResourceData resource)
    { 
        for (int i = 0; i < MAX_ITEM_COUNT; i++)
        {
            if (_items[i].IsFilled)
                continue;
            _items[i].Put(resource);
            return;
        }
    }

    public void RemoveItem(int slotIndex)
    {
        ResourceData resource = _items[slotIndex].Pick();
        if (resource != null)
        {
            ResourcePickup resourcePickup = Instantiate(_pickupPrefab, _player.transform.position, Quaternion.identity);
            resourcePickup.SetData(resource);
        }
    }
}