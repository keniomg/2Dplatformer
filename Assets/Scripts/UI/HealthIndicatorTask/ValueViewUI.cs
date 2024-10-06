using UnityEngine;

public abstract class ValueViewUI : MonoBehaviour
{
    [SerializeField] protected UIEventInvoker Eventer;
    [SerializeField] protected GameObject ViewedValueObject;

    protected void OnEnable()
    {
        Eventer.RegisterEvent(ViewedValueObject.name, OnValueChanged);
    }

    protected void OnDisable()
    {
        Eventer.UnregisterEvent(ViewedValueObject.name, OnValueChanged);
    }

    protected abstract void OnValueChanged(float currentValue);
}