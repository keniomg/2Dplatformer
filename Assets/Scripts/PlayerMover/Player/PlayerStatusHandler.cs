using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerMover))]

public class PlayerStatusHandler : MonoBehaviour
{
    [SerializeField] private Transform _groundCheckPoint;
    [SerializeField] private LayerMask _ground;

    private Rigidbody2D _rigidbody;
    private PlayerMover _playerMover;

    public bool IsRun { get; private set; }
    public bool IsFall { get; private set; }
    public bool IsJump { get; private set; }
    public bool IsGrounded { get; private set; }

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        ManageMovementStatus();
    }

    private void ManageMovementStatus()
    {
        ManageGroundedStatus();
        ManageFallAndJumpStatus();
        ManageRunStatus();
    }

    private void ManageGroundedStatus()
    {
        float checkRadius = 0.1f;
        IsGrounded = Physics2D.OverlapCircle(_groundCheckPoint.position, checkRadius, _ground);
    }

    private void ManageFallAndJumpStatus()
    {
        if (IsGrounded == false)
        {
            if (_rigidbody.velocity.y > 0)
            {
                IsJump = true;
                IsFall = false;
            }
            else if (_rigidbody.velocity.y < 0)
            {
                IsJump = false;
                IsFall = true;
            }
        }
        else
        {
            IsJump = false;
            IsFall = false;
        }
    }

    private void ManageRunStatus()
    {
        if (_playerMover.HorizontalAxisValue != 0)
        {
            IsRun = true;
        }
        else
        {
            IsRun = false;
        }
    }
}