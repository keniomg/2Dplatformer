using UnityEngine;

public abstract class HealthUI : MonoBehaviour
{
    protected Health Health;

    protected virtual void Initialize(Health health)
    {
        Health = health;
        Health.ValueChanged += OnHealthChanged;
    }

    protected abstract void OnHealthChanged(float currentHealth);
}