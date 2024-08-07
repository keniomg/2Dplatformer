using UnityEngine;

[RequireComponent(typeof(BearMover))]

public class BearStatusHandler : MonoBehaviour
{
    [SerializeField] private Transform _groundCheckPoint;
    [SerializeField] private LayerMask _ground;

    public bool IsWaiting { get; private set; }
    public bool IsMovingRight { get; private set; }
    public bool IsGroundNear {get; private set; }

    private void Start()
    {
        IsGroundNear = true;
    }

    private void Update()
    {
        ManageEdgeNearStatus();
    }

    public void ChangeMovingSideStatus()
    {
        IsMovingRight = !IsMovingRight;
    }

    private void ManageEdgeNearStatus()
    {
        Vector2 checkRayDirection;
        float checkRayDistance = 0.5f;

        if (IsMovingRight)
        {
            checkRayDirection = Vector2.right;
        }
        else
        {
            checkRayDirection = Vector2.left;
        }

        Vector2 groundCheckPosition = (Vector2)_groundCheckPoint.position + checkRayDirection * checkRayDistance;
        RaycastHit2D groundCheckInfo = Physics2D.Raycast(groundCheckPosition, checkRayDirection, checkRayDistance, _ground);
        IsGroundNear = groundCheckInfo.collider;
        IsWaiting = !IsGroundNear;
    }
}