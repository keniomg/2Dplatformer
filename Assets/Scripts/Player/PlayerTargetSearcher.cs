using UnityEngine;

public class PlayerTargetSearcher : TargetSearcher
{
    private PlayerMover _playerMover;

    public void Initialize(PlayerMover playerMover)
    {
        _playerMover = playerMover;
    }

    public override void InitializeTarget()
    {
        Target = GetTarget<BearHealth>();
    }

    public override TargetHealth GetTarget<TargetHealth>()
    {
        RaycastHit2D targetHit = Physics2D.Raycast(transform.position, _playerMover.MoveDirection, TargetSearchRadius, TargetLayer);

        if (targetHit.collider != null)
        {
            Vector2 directionToTarget = targetHit.transform.position - transform.position;
            RaycastHit2D groundHit = Physics2D.Raycast(transform.position, directionToTarget.normalized, directionToTarget.magnitude, Ground);

            if (groundHit.collider == null)
            {
                if (targetHit.collider.transform.parent.TryGetComponent(out TargetHealth targetHealth))
                {
                    return targetHealth;
                }
            }
        }

        return null;
    }
}