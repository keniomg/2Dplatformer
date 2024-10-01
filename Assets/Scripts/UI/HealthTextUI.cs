using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]

public class HealthTextUI : HealthUI
{
    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    protected override void OnHealthChanged(float currentHealth)
    {
        _text.text = $"{currentHealth*100}%";
    }
}