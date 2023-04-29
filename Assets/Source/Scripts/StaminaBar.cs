using UnityEngine;

public class StaminaBar : Bar
{
    [SerializeField] Player _player;

    private void OnEnable()
    {
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