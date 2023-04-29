﻿using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ResourcePickup : MonoBehaviour, IPickable
{
    private SpriteRenderer _spriteRenderer;
    private ResourceData _resourceData;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetData(ResourceData resourceData)
    {
        _resourceData = resourceData;
        _spriteRenderer.sprite = _resourceData.Icon;
    }

    public ResourceData Take()
    {
        Invoke(nameof(DestroyPickup), 0.01f);
        return _resourceData;
    }

    private void DestroyPickup()
    {
        Destroy(gameObject);
    }

}