using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public abstract class a_ResourceSource : MonoBehaviour
{
    [SerializeField] private ResourceData _itemData;

    public abstract void Take();
}