using UnityEngine;
using Jam.Player;

public class HealthBar : Bar
{
    private Player _player;

    private void OnEnable()
    {
        _player = FindObjectOfType<Player>();
        _player.ChangedHealth += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.ChangedHealth -= OnHealthChanged;
    }

    private void OnHealthChanged(float targetHealth)
    {
        StartBarChange(targetHealth, _player.Health);
    }
}