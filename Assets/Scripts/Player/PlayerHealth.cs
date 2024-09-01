using UnityEngine;

public class PlayerHealth : Health
{
    protected override void Start()
    {
        MaximumHealthValue = 150;
        int startHealthValue = MaximumHealthValue;
        CurrentHealthValue = startHealthValue;
    }

    public override void DecreaseHealth(int decreaseValue)
    {
        base.DecreaseHealth(decreaseValue);
        PrintHealthMessage();
    }

    public override void IncreaseHealth(int increaseValue)
    {
        base.IncreaseHealth(increaseValue);
        PrintHealthMessage();
    }

    private void PrintHealthMessage()
    {
        string healthMessage = $"Текущее здоровье игрока - {CurrentHealthValue}";
        Debug.Log(healthMessage);
    }
}