using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maximumHealthValue;

    protected int MinimumHealthValue;

    public int CurrentHealthValue { get; protected set; }
    public int MaximumHealthValue => _maximumHealthValue;

    protected void Start()
    {
        MinimumHealthValue = 0;
        CurrentHealthValue = _maximumHealthValue;
    }

    public void DecreaseHealth(int decreaseValue)
    {
        if (decreaseValue >= 0)
        {
            CurrentHealthValue = Mathf.Clamp(CurrentHealthValue - decreaseValue, MinimumHealthValue, _maximumHealthValue);
        }
    }

    public void IncreaseHealth(int increaseValue)
    {
        if (increaseValue >= 0)
        {
            CurrentHealthValue = Mathf.Clamp(CurrentHealthValue + increaseValue, MinimumHealthValue, _maximumHealthValue);
        }
    }
}