using TMPro;
using UnityEngine;

public class ExhaustibleResourceSource : a_ResourceSource, IPickable
{
    [SerializeField] private int _resourceCount;
    [SerializeField] private TMP_Text _countText;

    private void UpdateText()
    {
        _countText.text = _resourceCount.ToString();
    }

    public override ResourceData Take()
    {
        if (_resourceCount <= 0)
            return null;

        _resourceCount--;
        UpdateText();

        return _resourceData;
    }

}