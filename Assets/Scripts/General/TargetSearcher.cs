using UnityEngine;

public class TargetSearcher : MonoBehaviour
{
    [SerializeField] protected float _targetSearchRadius;
    [SerializeField] protected LayerMask _targetLayer;
    [SerializeField] protected LayerMask _ground;

    public Health Target { get; protected set; }
    public float TargetSearchRadius => _targetSearchRadius;
    public LayerMask TargetLayer => _targetLayer;
    public LayerMask Ground => _ground;

    public virtual void InitializeTarget<TargetHealth>() where TargetHealth : Health
    {
        Target = GetTarget<TargetHealth>();
    }

    public virtual TargetHealth GetTarget<TargetHealth>() where TargetHealth : Health
    {
        Collider2D targetHit = Physics2D.OverlapCircle(transform.position, TargetSearchRadius, TargetLayer);

        if (targetHit != null)
        {
            Vector2 directionToTarget = targetHit.transform.position - transform.position;
            RaycastHit2D groundHit = Physics2D.Raycast(transform.position, directionToTarget.normalized, directionToTarget.magnitude, Ground);

            if (groundHit.collider == null)
            {
                if (targetHit.TryGetComponent(out TargetHealth targetHealth) || targetHit.transform.parent.TryGetComponent(out targetHealth))
                {
                    return targetHealth;
                }
            }
        }

        return null;
    }
}