using System.Collections;
using UnityEngine;

public class SmoothValueBarViewUI : ValueBarViewUI
{
    private WaitForSeconds _waitForSeconds;
    private Coroutine _valueChangingCoroutine;

    protected override void Awake()
    {
        base.Awake();

        float valueChangingTime = 0.001f;
        _waitForSeconds = new WaitForSeconds(valueChangingTime);
    }

    protected override void OnValueChanged(float currentValue)
    {
        if (_valueChangingCoroutine != null)
        {
            StopCoroutine(_valueChangingCoroutine);
        }

        _valueChangingCoroutine = StartCoroutine(ChangeHealth(currentValue));
    }

    private IEnumerator ChangeHealth(float currentValue)
    {
        float maxDelta = 1f;

        while (Slider.value != currentValue)
        {
            Slider.value = Mathf.MoveTowards(Slider.value, currentValue, maxDelta * Time.deltaTime);
            yield return _waitForSeconds;
        }
    }
}