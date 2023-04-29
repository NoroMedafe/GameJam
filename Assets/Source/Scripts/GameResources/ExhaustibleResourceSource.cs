using TMPro;
using UnityEngine;

public class ExhaustibleResourceSource : a_ResourceSource
{
    [SerializeField] private int _resourceCount;
    [SerializeField] private TMP_Text _countText;

    private void UpdateText()
    {
        _countText.text = _resourceCount.ToString();
    }

    public override void Take()
    {
        if (_resourceCount <= 0)
            return;

        _resourceCount--;
        UpdateText();

        Debug.Log("Wow!");
    }
}