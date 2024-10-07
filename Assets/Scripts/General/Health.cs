using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected UIEventInvoker Eventer;

    [SerializeField] private float _maximumValue;

    protected float MinimumValue;

    public event Action<float> ValueChanged;

    public float CurrentValue { get; protected set; }
    public float MaximumValue => _maximumValue;

    protected void Awake()
    {
        MinimumValue = 0;
        CurrentValue = _maximumValue;
    }

    protected virtual void Start()
    {
        Eventer.RegisterEvent(name, ValueChanged);
    }

    private void OnDisable()
    {
        Eventer.UnregisterEvent(name, ValueChanged);
    }

    public void Decrease(float decreaseValue)
    {
        if (decreaseValue >= 0)
        {
            CurrentValue = Mathf.Clamp(CurrentValue - decreaseValue, MinimumValue, _maximumValue);
            Eventer.InvokeEvent(name, CurrentValue / MaximumValue);
        }
    }

    public void Increase(float increaseValue)
    {
        if (increaseValue >= 0)
        {
            CurrentValue = Mathf.Clamp(CurrentValue + increaseValue, MinimumValue, _maximumValue);
            Eventer.InvokeEvent(name, CurrentValue / MaximumValue);
        }
    }
}