using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public abstract class a_ResourceSource : MonoBehaviour
{
    [SerializeField] protected ResourceData _resourceData;
    public ResourceData Resource => _resourceData;

    public abstract ResourceData Take();
}