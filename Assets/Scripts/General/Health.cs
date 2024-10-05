using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected UIEventer Eventer;

    [SerializeField] private float _maximumHealthValue;

    public event Action<float> HealthValueChanged;

    protected float MinimumHealthValue;

    public float CurrentHealthValue { get; protected set; }
    public float MaximumHealthValue => _maximumHealthValue;

    protected void Awake()
    {
        MinimumHealthValue = 0;
        CurrentHealthValue = _maximumHealthValue;
    }

    protected virtual void Start()
    {
        Eventer.RegisterEvent(name, HealthValueChanged);
    }

    private void OnDisable()
    {
        Eventer.UnregisterEvent(name, HealthValueChanged);
    }

    public void Decrease(float decreaseValue)
    {
        if (decreaseValue >= 0)
        {
            CurrentHealthValue = Mathf.Clamp(CurrentHealthValue - decreaseValue, MinimumHealthValue, _maximumHealthValue);
            Eventer.InvokeEvent(name, CurrentHealthValue / MaximumHealthValue);
        }
    }

    public void Increase(float increaseValue)
    {
        if (increaseValue >= 0)
        {
            CurrentHealthValue = Mathf.Clamp(CurrentHealthValue + increaseValue, MinimumHealthValue, _maximumHealthValue);
            Eventer.InvokeEvent(name, CurrentHealthValue / MaximumHealthValue);
        }
    }
}