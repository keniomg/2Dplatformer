public class BearHealthHandler : HealthHandler
{
    protected override void Start()
    {
        int startHealthValue = 50;
        _currentHealthValue = startHealthValue;
    }
}