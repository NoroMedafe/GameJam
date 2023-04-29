using UnityEngine;

internal class InexhaustibleResoureSource : a_ResourceSource, IPickable
{
    public override ResourceData Take()
    {
        return _resourceData;
    }
}
