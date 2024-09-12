public class Cherry : InteractiveObject
{
    public int HealingValue {get; private set; }

    protected override void Start()
    {
        base.Start();
        HealingValue = 25;
    }
}