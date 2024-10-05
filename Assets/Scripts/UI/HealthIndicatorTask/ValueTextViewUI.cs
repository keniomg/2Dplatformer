using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ValueTextViewUI : ValueViewUI
{
    private TextMeshProUGUI _text;

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    protected override void OnValueChanged(float currentValue)
    {
        const int TotalPercentCount = 100;
        _text.text = $"{currentValue * TotalPercentCount}%";
    }
}