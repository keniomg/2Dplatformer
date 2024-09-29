using TMPro;
using UnityEngine;

public class PlayerHealthTextUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private PlayerHealth _health;

    public void Initialize(PlayerHealth health)
    {
        _health = health;
    }

    public void ManageHealthText()
    {
        _text.text = $"{_health.CurrentHealthValue}/{_health.MaximumHealthValue}";
    }
}