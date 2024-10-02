using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected Eventer Eventer;
    [SerializeField] private float _maximumHealthValue;

    public event Action<float> ValueChanged;

    protected float MinimumHealthValue;

    public float CurrentHealthValue { get; protected set; }
    public float MaximumHealthValue => _maximumHealthValue;

    protected void Awake()
    {
        MinimumHealthValue = 0;
        CurrentHealthValue = _maximumHealthValue;
    }

    public void DecreaseHealth(float decreaseValue)
    {
        if (decreaseValue >= 0)
        {
            CurrentHealthValue = Mathf.Clamp(CurrentHealthValue - decreaseValue, MinimumHealthValue, _maximumHealthValue);
            ValueChanged?.Invoke(CurrentHealthValue / MaximumHealthValue);
        }
    }

    public void IncreaseHealth(float increaseValue)
    {
        if (increaseValue >= 0)
        {
            CurrentHealthValue = Mathf.Clamp(CurrentHealthValue + increaseValue, MinimumHealthValue, _maximumHealthValue);
            ValueChanged?.Invoke(CurrentHealthValue / MaximumHealthValue);
        }
    }
}