using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ValueBarViewUI : ValueViewUI 
{
    protected Slider Slider;

    protected virtual void Awake()
    {
        Slider = GetComponent<Slider>();
    }

    protected override void OnValueChanged(float currentValue)
    {
        Slider.value = currentValue;
    }
}