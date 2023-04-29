using UnityEngine;

[CreateAssetMenu(menuName = "Resources/ResourceData")]
public class ResourceData : ScriptableObject
{
    [SerializeField] private int _id;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;

    public int Id => _id;
    public string Name => _name;
    public Sprite Icon => _icon;
}