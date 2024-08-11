using UnityEngine;

public class GroundDetector : MonoBehaviour
{
    [SerializeField] private Transform _groundCheckPoint;
    [SerializeField] private LayerMask _ground;

    private float _checkRadius = 0.1f;

    public bool IsGrounded => Physics2D.OverlapCircle(_groundCheckPoint.position, _checkRadius, _ground);
}