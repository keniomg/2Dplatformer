using UnityEngine;

public abstract class HealthUI : MonoBehaviour
{
    [SerializeField] protected Eventer Eventer;

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

    protected virtual void Initialize(PlayerHealth playerHealth)
    {
        Health = playerHealth;
        Health.ValueChanged += OnHealthChanged;
    }

    protected abstract void OnHealthChanged(float currentHealth);
}