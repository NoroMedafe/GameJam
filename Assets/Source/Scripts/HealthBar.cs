using UnityEngine;

public class HealthBar : Bar
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
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