using UnityEngine;

public class BearStatus : Status
{
    private BearAttacker _bearAttacker;
    private BearGroundDetector _groundDetector;

    public Vector2 MoveDirection { get; private set; }
    public bool IsRun { get; private set; }
    public bool IsGroundNear => _groundDetector.GetGroundNearStatus();
    public bool IsAttack => _bearAttacker.IsAttack;
    public bool IsWaiting => _bearAttacker.IsWaiting;

    public void Initialize(BearGroundDetector bearGroundDetector, BearAttacker bearAttacker)
    {
        _groundDetector = bearGroundDetector;
        _bearAttacker = bearAttacker;
    }

    public void SetRunStatus()
    {
        IsRun = true;
    }

    public void ResetRunStatus()
    {
        IsRun = false;
    }

    public void InitializeMoveDirection(Vector2 moveDirection)
    {
        MoveDirection = moveDirection;
        _groundDetector.SetCheckRayDirection(MoveDirection);
    }
}