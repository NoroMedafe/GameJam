using UnityEngine;
using Jam.Player;

[RequireComponent(typeof(SpriteRenderer))]
public class MissionIndicator : MonoBehaviour
{
    [SerializeField] private float _distaneFromPlayer;

    private Player _player;
    private Vector2 _linkedOutpostPosition;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        GetComponent<SpriteRenderer>();
        _player = FindObjectOfType<Player>();
    }

    public void SetTarget(Vector2 position)
    {
        _linkedOutpostPosition = position;
    }

    private void Update()
    {
        transform.position = (_linkedOutpostPosition - (Vector2)_player.transform.position).normalized * _distaneFromPlayer;
    }
}
