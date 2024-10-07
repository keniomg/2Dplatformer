using System;
using System.Collections;
using UnityEngine;

public class Vampirism : MonoBehaviour
{
    [SerializeField] protected UIEventInvoker TimeLeftEventer;
    [SerializeField] protected UIEventInvoker CooldownEventer;

    protected VampirismTargetSearcher TargetSearcher;

    private int _valuePerSecond = 5;
    private int _duration = 6;
    private int _cooldown = 3;
    private bool _isAvailable;
    private Health _selfHealth;
    private WaitForSeconds _delay;
    private WaitForSeconds _cooldownDelay;

    public event Action<float> DurationLeftChanged;
    public event Action<float> CooldownChanged;

    public int DurationLeft { get; private set; }
    public int CurrentCooldown { get; private set; }
    public bool IsActive { get; private set; }
    public float Radius => TargetSearcher.TargetSearchRadius;
    public int MaximumDuration => _duration;
    public int MaximumCooldown => _cooldown;

    private void Start()
    {
        TimeLeftEventer.RegisterEvent(name, DurationLeftChanged);
        CooldownEventer.RegisterEvent(name, CooldownChanged);
        _isAvailable = true;
        const int SecondDelay = 1;
        _delay = new WaitForSeconds(SecondDelay);
        _cooldownDelay = new WaitForSeconds(SecondDelay);
    }

    public void Initialize(Health health, VampirismTargetSearcher targetSearcher)
    {
        _selfHealth = health;
        TargetSearcher = targetSearcher;
    }

    public virtual void OnButtonPressed()
    {
        if (_isAvailable)
        {
            StartCoroutine(Cast());
        }
    }

    private IEnumerator Cast()
    {
        IsActive = true;
        _isAvailable = false;
        DurationLeft = _duration;

        while (DurationLeft > 0)
        {
            if (TargetSearcher.NearestTarget != null)
            {
                TargetSearcher.NearestTarget.Decrease(_valuePerSecond);
                _selfHealth.Increase(_valuePerSecond);
            }

            yield return _delay;

            DurationLeft--;
            InvokeAbilityEvent(TimeLeftEventer, DurationLeft, MaximumDuration);
        }

        IsActive = false;
        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        CurrentCooldown = 0;
        InvokeAbilityEvent(CooldownEventer, CurrentCooldown, MaximumCooldown);

        while (CurrentCooldown < _cooldown)
        {
            yield return _cooldownDelay;

            CurrentCooldown++;
            InvokeAbilityEvent(CooldownEventer, CurrentCooldown, MaximumCooldown);
        }

        DurationLeft = MaximumDuration;
        InvokeAbilityEvent(TimeLeftEventer, DurationLeft, MaximumDuration);
        _isAvailable = true;
    }

    private void InvokeAbilityEvent(UIEventInvoker eventer, int currentValue, int maximumValue)
    {
        float abilityCoefficient = (float)currentValue / maximumValue;
        eventer.InvokeEvent(name, abilityCoefficient);
    }
}