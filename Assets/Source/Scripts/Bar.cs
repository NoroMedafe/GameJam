using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] private Image _image;
    private float Fill
    {
        get => _image.fillAmount;
        set => _image.fillAmount = value;
    }

    private Coroutine _coroutine;
    private float _stepSpeed = .1f;

    protected void StartBarChange(float targetHealth, float maxHealth)
    {
        if (_coroutine != null)
            StopCoroutine(_coroutine);

        _coroutine = StartCoroutine(ChangeSlider(targetHealth, maxHealth));
    }

    private IEnumerator ChangeSlider(float targetHealth, float maxHealth)
    {
        targetHealth /= maxHealth;

        while (Fill != targetHealth)
        {
            Fill = Mathf.MoveTowards(Fill, targetHealth, _stepSpeed * Time.deltaTime);
            yield return null;
        }
    }
}