using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarUI : MonoBehaviour
{
    [SerializeField] protected Slider Slider;

    protected PlayerHealth Health;

    public void Initialize(PlayerHealth health)
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