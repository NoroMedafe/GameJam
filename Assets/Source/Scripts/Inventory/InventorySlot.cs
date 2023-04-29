using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private Image _image;
    [SerializeField] private Sprite _emptySprite;
    private ResourceData _resource;

    public bool IsFilled { get; private set; } = false;
    public ResourceData Resource
    {
        set
        {
            _resource = value;
            _image.sprite = value?.Icon ?? _emptySprite;
        }
    }

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void Put(ResourceData resource)
    {
        if (IsFilled)
            return;

        Resource = resource;
        IsFilled = true;
    }

    public ResourceData Pick()
    {
        if (!IsFilled)
            return null;

        ResourceData resource = _resource;
        Resource = null;
        IsFilled = false;
        return resource;
    }
}