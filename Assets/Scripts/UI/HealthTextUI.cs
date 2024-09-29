using TMPro;
using UnityEngine;

public class HealthTextUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private Health _health;

    public void Initialize(Health health)
    {
        _health = health;
    }

    public void ManageHealthText()
    {
        _text.text = $"{_health.CurrentHealthValue}/{_health.MaximumHealthValue}";
    }
}