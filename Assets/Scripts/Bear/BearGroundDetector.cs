using UnityEngine;

public class BearGroundDetector : GroundDetector
{
    private BearMover _bearMover;

    private void Start()
    {
        _bearMover = TryGetComponent(out BearMover bearMover) ? bearMover : null;
    }

    public bool GetGroundNearStatus()
    {
        float checkRayDistance = 0.5f;

        Vector2 groundCheckPosition = (Vector2)GroundCheckPoint.position + _bearMover.Direction * checkRayDistance;
        RaycastHit2D groundCheckInfo = Physics2D.Raycast(groundCheckPosition, _bearMover.Direction, checkRayDistance, Ground);

        return groundCheckInfo;
    }
}