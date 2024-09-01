using UnityEngine;

public class Health : MonoBehaviour
{
    protected int CurrentHealthValue;
    protected int MaximumHealthValue;
    protected int MinimumHealthValue;

    protected virtual void Start()
    {
        int startHealthValue = 100;
        CurrentHealthValue = startHealthValue;
        MinimumHealthValue = 0;
        MaximumHealthValue = 100;
    }

    public virtual void DecreaseHealth(int decreaseValue)
    {
        CurrentHealthValue -= decreaseValue;

        if (CurrentHealthValue < MinimumHealthValue)
        {
            CurrentHealthValue = MinimumHealthValue;
        }
    }

    public virtual void IncreaseHealth(int increaseValue)
    {
        CurrentHealthValue += increaseValue;

        if (CurrentHealthValue > MaximumHealthValue)
        {
            CurrentHealthValue = MaximumHealthValue;
        }
    }
}