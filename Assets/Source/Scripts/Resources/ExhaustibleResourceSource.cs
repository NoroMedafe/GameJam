using UnityEngine;

internal class ExhaustibleResoureSource : a_ResourceSource
{
    [SerializeField] private int _resourceCount;

    public override void Take()
    {
        if (_resourceCount <= 0)
            return;

        _resourceCount--;      
    }
}
