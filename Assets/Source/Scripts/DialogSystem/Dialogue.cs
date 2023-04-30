using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [SerializeField] private string _name;

    [TextArea(3, 10)]
    [SerializeField] private string[] _sentences;

    public string Name => _name;
    public string[] Sentences => _sentences;
}