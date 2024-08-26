using UnityEngine;

[RequireComponent(typeof(BearMover), typeof(HealthHandler), typeof(BearAttackHandler))]

public class BearStatusHandler : StatusHandler
{
    [SerializeField] private Transform _groundCheckPoint;
    [SerializeField] private LayerMask _ground;

    private BearAttackHandler _bearAttackHandler;
    private BearMover _bearMover;

    public bool IsRun { get; private set; }
    public bool IsGroundNear => GetGroundNearStatus();
    public bool IsAttack => _bearAttackHandler.IsAttack;

    private void Start()
    {
        _bearAttackHandler = GetComponent<BearAttackHandler>();
        _bearMover = GetComponent<BearMover>();
    }

    public void SetRunStatus()
    {
        IsRun = true;
    }

    public void ResetRunStatus()
    {
        IsRun = false;
    }

    private bool GetGroundNearStatus()
    {
        float checkRayDistance = 0.5f;

        Vector2 groundCheckPosition = (Vector2)_groundCheckPoint.position + _bearMover.Direction * checkRayDistance;
        RaycastHit2D groundCheckInfo = Physics2D.Raycast(groundCheckPosition, _bearMover.Direction, checkRayDistance, _ground);

        return groundCheckInfo;
    }
}