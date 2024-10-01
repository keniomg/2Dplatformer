using UnityEngine;

public class HealthUI : MonoBehaviour
{
    protected PlayerHealth Health;

    private void OnEnable()
    {
        Eventer.PlayerHealthCreated += Initialize;
    }

    private void OnDisable()
    {
        Eventer.PlayerHealthCreated -= Initialize;

        if (Health != null)
        {
            Health.ValueChanged -= OnHealthChanged;
        }
    }

    protected virtual void OnHealthChanged(float currentHealth) { }

    protected virtual void Initialize(PlayerHealth playerHealth)
    {
        Health = playerHealth;
        Health.ValueChanged += OnHealthChanged;
    }
}