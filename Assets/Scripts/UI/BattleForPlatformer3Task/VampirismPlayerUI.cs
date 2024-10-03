using UnityEngine;
using UnityEngine.UI;

public class VampirismPlayerUI : MonoBehaviour
{
    [SerializeField] private Slider _cooldown;
    [SerializeField] private Slider _abilityDuration;

    private PlayerVampire _playerVampire;

    private void Start()
    {
    }

    public void Initialize(PlayerVampire playerVampire)
    {
        _playerVampire = playerVampire;
        _cooldown.maxValue = _playerVampire.MaximumAbilityCooldown;
        _abilityDuration.maxValue = _playerVampire.MaximumAbilityDuration;
    }

    public void ManageAbilityUI()
    {
        _cooldown.value = _playerVampire.CurrentAbilityCooldown;
        _abilityDuration.value = _playerVampire.AbilityDurationLeft;
    }
}