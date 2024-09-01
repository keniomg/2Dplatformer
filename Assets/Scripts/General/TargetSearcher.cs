using UnityEngine;

public class TargetSearcher : MonoBehaviour
{
    [SerializeField] protected float TargetSearchRadius;
    [SerializeField] protected LayerMask TargetLayer;
    [SerializeField] protected LayerMask Ground;

    public Vector2 DirectionToTarget { get; private set; }
    public Health Target { get; protected set; }

    protected TargetHealth GetTarget<TargetHealth>() where TargetHealth : Health
    {
        Collider2D targetHit = Physics2D.OverlapCircle(transform.position, TargetSearchRadius, TargetLayer);

        if (targetHit != null)
        {
            Vector2 directionToTarget = targetHit.transform.position - transform.position;
            RaycastHit2D groundHit = Physics2D.Raycast(transform.position, directionToTarget.normalized, directionToTarget.magnitude, Ground);

            if (groundHit.collider == null)
            {
                DirectionToTarget = directionToTarget.normalized;

                if (targetHit.TryGetComponent(out TargetHealth targetHealth) || targetHit.transform.parent.TryGetComponent(out targetHealth))
                {
                    return targetHealth;
                }
            }
        }

        return null;
    }

    protected Vector2 AngleToVector(float angle)
    {
        float radian = angle * Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
    }
}