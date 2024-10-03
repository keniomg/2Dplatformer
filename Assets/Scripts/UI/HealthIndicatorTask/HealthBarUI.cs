using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public abstract class HealthBarUI : HealthUI 
{
    protected Slider Slider;

    protected virtual void Awake()
    {
        Slider = GetComponent<Slider>();
    }

    protected override void OnHealthChanged(float currentHealth)
    {
        Slider.value = currentHealth;
    }
}