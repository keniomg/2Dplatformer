using System;
using System.Collections;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] protected UIEventInvoker TimeLeftEventer;
    [SerializeField] protected UIEventInvoker CooldownEventer;

    public event Action<float> AbilityDurationLeftChanged;
    public event Action<float> AbilityCooldownChanged;
    
    protected VampirismTargetSearcher TargetSearcher;

    private int _vampirismPerSecond = 5;
    private int _abilityDuration = 6;
    private int _abilityCooldown = 3;
    private bool _isAbilityAvailable;
    private Health _selfHealth;
    private WaitForSeconds _vampirismDelay;
    private WaitForSeconds _cooldownDelay;

    public int AbilityDurationLeft { get; private set; }
    public int CurrentAbilityCooldown { get; private set; }
    public bool IsAbilityActive { get; private set; }
    public float VampirismRadius => TargetSearcher.TargetSearchRadius;
    public int MaximumAbilityDuration => _abilityDuration;
    public int MaximumAbilityCooldown => _abilityCooldown;

    private void Start()
    {
        TimeLeftEventer.RegisterEvent(name, AbilityDurationLeftChanged);
        CooldownEventer.RegisterEvent(name, AbilityCooldownChanged);
        _isAbilityAvailable = true;
        const int SecondDelay = 1;
        _vampirismDelay = new WaitForSeconds(SecondDelay);
        _cooldownDelay = new WaitForSeconds(SecondDelay);
    }

    public void Initialize(Health health, VampirismTargetSearcher targetSearcher)
    {
        _selfHealth = health;
        TargetSearcher = targetSearcher;
    }

    public virtual void OnButtonPressed()
    {
        if (_isAbilityAvailable)
        {
            StartCoroutine(CastVampirism());
        }
    }

    private IEnumerator CastVampirism()
    {
        IsAbilityActive = true;
        _isAbilityAvailable = false;
        AbilityDurationLeft = _abilityDuration;

        while (AbilityDurationLeft > 0)
        {
            if (TargetSearcher.NearestTarget != null)
            {
                TargetSearcher.NearestTarget.Decrease(_vampirismPerSecond);
                _selfHealth.Increase(_vampirismPerSecond);
            }

            yield return _vampirismDelay;

            AbilityDurationLeft--;
            InvokeAbilityEvent(TimeLeftEventer, AbilityDurationLeft, MaximumAbilityDuration);
        }

        IsAbilityActive = false;
        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        CurrentAbilityCooldown = 0;
        InvokeAbilityEvent(CooldownEventer, CurrentAbilityCooldown, MaximumAbilityCooldown);

        while (CurrentAbilityCooldown < _abilityCooldown)
        {
            yield return _cooldownDelay;

            CurrentAbilityCooldown++;
            InvokeAbilityEvent(CooldownEventer, CurrentAbilityCooldown, MaximumAbilityCooldown);
        }

        AbilityDurationLeft = MaximumAbilityDuration;
        InvokeAbilityEvent(TimeLeftEventer, AbilityDurationLeft, MaximumAbilityDuration);
        _isAbilityAvailable = true;
    }

    private void InvokeAbilityEvent(UIEventInvoker eventer, int currentValue, int maximumValue)
    {
        float abilityCoefficient = (float)currentValue / maximumValue;
        Debug.Log(abilityCoefficient);
        eventer.InvokeEvent(name, abilityCoefficient);
    }
}