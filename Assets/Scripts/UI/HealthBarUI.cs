using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBarUI : HealthUI
{
    protected Slider Slider;

    private void Start()
    {
        Slider = GetComponent<Slider>();
    }

    protected override void OnHealthChanged(float currentHealth)
    {
        Slider.value = currentHealth;
    }

    protected override void Initialize(PlayerHealth playerHealth)
    {
        base.Initialize(playerHealth); 
        Slider.value = playerHealth.CurrentHealthValue;
    }
}