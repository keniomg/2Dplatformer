using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] protected Slider Slider;

    protected Health Health;

    public void Initialize(Health health)
    {
        Health = health;
    }

    public void SetMaxValue()
    {
        Slider.maxValue = Health.MaximumHealthValue;
    }

    public virtual void ManageHealthBar()
    {
        Slider.value = Health.CurrentHealthValue;
    }
}