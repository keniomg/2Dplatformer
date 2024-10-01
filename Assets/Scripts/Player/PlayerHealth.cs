public class PlayerHealth : Health 
{
    private void Start()
    {
        Eventer.OnPlayerHealthCreated(this);
    }
}