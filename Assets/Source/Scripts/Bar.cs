using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private Coroutine _coroutine;
    private float _stepSpeed = .1f;

    protected void StartHealthChange(float targetHealth, float maxHealth)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeSlider(targetHealth, maxHealth));
    }

    private IEnumerator ChangeSlider(float targetHealth, float maxHealth)
    {
        targetHealth /= maxHealth;

        while (_slider.value != targetHealth)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, targetHealth, _stepSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
