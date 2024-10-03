using System.Collections;
using UnityEngine;

public class SmoothHealthBarUI : HealthBarUI
{
    private WaitForSeconds _waitForSeconds;
    private Coroutine _healthChangingCoroutine;

    protected override void Awake()
    {
        base.Awake();

        float healthChangingTime = 0.001f;
        _waitForSeconds = new WaitForSeconds(healthChangingTime);
    }

    protected override void OnHealthChanged(float currentHealth)
    {
        if (_healthChangingCoroutine != null)
        {
            StopCoroutine(_healthChangingCoroutine);
        }

        _healthChangingCoroutine = StartCoroutine(ChangeHealth(currentHealth));
    }

    private IEnumerator ChangeHealth(float currentHealth)
    {
        float maxDelta = 1f;

        while (Slider.value != currentHealth)
        {
            Slider.value = Mathf.MoveTowards(Slider.value, currentHealth, maxDelta * Time.deltaTime);
            yield return _waitForSeconds;
        }
    }
}