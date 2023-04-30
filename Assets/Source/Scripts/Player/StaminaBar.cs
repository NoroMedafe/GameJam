using UnityEngine;

public class StaminaBar : Bar
{
    Player _player;

    private void OnEnable()
    {
        _player = FindObjectOfType<Player>();
        _player.ChangedStamina += OnStaminaChanged;
    }

    private void OnDisable()
    {
        _player.ChangedStamina -= OnStaminaChanged;
    }

    private void OnStaminaChanged(float targetStamina)
    {
        StartBarChange(targetStamina, _player.Stamina);
    }
}