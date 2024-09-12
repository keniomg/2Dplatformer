using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected int MaximumHealthValue;

    protected int CurrentHealthValue;
    protected int MinimumHealthValue;

    protected virtual void Start()
    {
        MinimumHealthValue = 0;
        CurrentHealthValue = MaximumHealthValue;
    }

    public virtual void DecreaseHealth(int decreaseValue)
    {
        if (decreaseValue >= 0)
        {
            CurrentHealthValue = Mathf.Clamp(CurrentHealthValue - decreaseValue, MinimumHealthValue, MaximumHealthValue);
        }
    }

    public virtual void IncreaseHealth(int increaseValue)
    {
        if (increaseValue >= 0)
        {
            CurrentHealthValue = Mathf.Clamp(CurrentHealthValue + increaseValue, MinimumHealthValue, MaximumHealthValue);
        }
    }
}