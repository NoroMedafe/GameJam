using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private Item[] _items = new Item[2];
    private int _maxCountItem = 2;

    public void AddItem()
    {
        if (_items.Length < _maxCountItem)
        {
            
        }
    }

    public void RemoveItem()
    {

    }
}
