using UnityEngine;

public class BearGroundDetector : GroundDetector
{
    private Vector2 _checkRayDirection;

    public bool GetGroundNearStatus()
    {
        float checkRayDistance = 0.5f;

        Vector2 groundCheckPosition = (Vector2)GroundCheckPoint.position + _checkRayDirection * checkRayDistance;
        RaycastHit2D groundCheckInfo = Physics2D.Raycast(groundCheckPosition, _checkRayDirection, checkRayDistance, Ground);

        return groundCheckInfo;
    }

    public void SetCheckRayDirection(Vector2 moveDirection)
    {
        _checkRayDirection = moveDirection;
    }
}