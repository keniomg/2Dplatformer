using UnityEngine;

public class TargetSearcher : MonoBehaviour
{
    [SerializeField] protected Mover _mover;
    [SerializeField] protected HealthHandler _ownHealthHandler;
    [SerializeField] protected float _targetSearchRadius;
    [SerializeField] protected float _searchAngle;
    [SerializeField] protected LayerMask _target;
    [SerializeField] protected LayerMask _ground;

    protected int _collisionDetectionRaysCount;
    protected float _rayAngleStep;
    protected float _leftStartAngle;
    protected float _rightStartAngle;

    public Vector2 DirectionToTarget { get; private set; }
    public HealthHandler Target {get; protected set; }

    protected virtual void Start()
    {
        _leftStartAngle = 157.5f;
        _rightStartAngle = -22.5f;
        int raysCountDivider = 10;
        _collisionDetectionRaysCount = Mathf.CeilToInt(_searchAngle / raysCountDivider);
        _rayAngleStep = _searchAngle / (_collisionDetectionRaysCount + 1);
    }

    protected TargetHealthHandler GetTarget<TargetHealthHandler>() where TargetHealthHandler : HealthHandler
    {
        float startAngle = _mover.Direction == Vector2.right ? _rightStartAngle : _leftStartAngle;

        for (int i = 0; i < _collisionDetectionRaysCount; i++)
        {
            float rayAngle = startAngle + i * _rayAngleStep;
            Vector2 directionToTarget = AngleToVector(rayAngle);
            RaycastHit2D groundHit = Physics2D.Raycast(transform.position, directionToTarget, _targetSearchRadius, _ground);
            RaycastHit2D targetHit = Physics2D.Raycast(transform.position, directionToTarget, _targetSearchRadius, _target);

            if (targetHit && !groundHit)
            {
                if (targetHit.collider.TryGetComponent(out TargetHealthHandler targetHealthHandler))
                {
                    DirectionToTarget = directionToTarget;
                    return targetHealthHandler;
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