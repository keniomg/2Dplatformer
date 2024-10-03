using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public abstract class HealthTextUI : HealthUI
{
    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    protected override void OnHealthChanged(float currentHealth)
    {
        const int TotalPercentCount = 100;
        _text.text = $"{currentHealth * TotalPercentCount}%";
    }
}