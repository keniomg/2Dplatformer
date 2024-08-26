using System;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D), typeof(PlayerHealthHandler))]

public class PlayerCollisionHandler : MonoBehaviour
{
    private PlayerHealthHandler _healthHandler;

    public event Action PlayerCollisionCherry;

    private void Start()
    {
        _healthHandler = GetComponent<PlayerHealthHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Diamond diamond))
        {
            diamond.SetPickedUpStatus();
        }
        else if (collision.TryGetComponent(out Cherry cherry))
        {
            CollisionCherry(cherry);
        }
    }

    private void CollisionCherry(Cherry cherry)
    {
        _healthHandler.InitializeCherry(cherry);
        PlayerCollisionCherry?.Invoke();
        cherry.SetPickedUpStatus();
    }
}