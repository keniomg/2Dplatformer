using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D), typeof(CollisionHandler))]

public class PlayerCollisionManager : MonoBehaviour
{
    private CollisionHandler _collisionHandler;

    private void Start()
    {
        _collisionHandler = GetComponent<CollisionHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Diamond diamond))
        {
            _collisionHandler.PlayerCollisionDiamond(diamond);
        }
    }
}