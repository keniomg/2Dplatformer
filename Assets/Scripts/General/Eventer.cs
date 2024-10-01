using System;

public static class Eventer
{
    public static event Action<PlayerHealth> PlayerHealthCreated;

    public static void OnPlayerHealthCreated(PlayerHealth playerHealth)
    {
        PlayerHealthCreated?.Invoke(playerHealth);
    }
}