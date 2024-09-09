using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
    private PlayerHealth _health;

    public void Initialize(PlayerHealth playerHealth)
    {
        _health = playerHealth;
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
        _health.IncreaseHealth(cherry.HealingValue);
        cherry.SetPickedUpStatus();
    }
}