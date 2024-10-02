using System;
using UnityEngine;

public class Eventer : MonoBehaviour
{
    public event Action<PlayerHealth> PlayerHealthCreated;

    public void OnPlayerHealthCreated(PlayerHealth playerHealth)
    {
        PlayerHealthCreated?.Invoke(playerHealth);
    }
}