using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CapsuleCollider2D), typeof(PlayerStatusHandler))]
[RequireComponent(typeof(PlayerAnimatorHandler), typeof(PlayerInputReader), typeof(GroundDetector))]

public class PlayerMover : Mover
{
    [SerializeField] private float _jumpForce;

    private GroundDetector _groundDetector;
    private Rigidbody2D _rigidbody;
    private PlayerInputReader _playerInputReader;

    private void Start()
    {
        _groundDetector = GetComponent<GroundDetector>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerInputReader = GetComponent<PlayerInputReader>();
    }

    private void Update()
    {
        ManageDirection();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void ManageDirection()
    {
        if (_rigidbody.velocity.x != 0)
            Direction = _rigidbody.velocity.x > 0 ? Vector2.right : Vector2.left;
    }

    private void Move()
    {
        Run();
        Jump();
    }

    private void Run()
    {
        Vector2 horizontalMovement = new(_playerInputReader.HorizontalAxisValue * _speed, _rigidbody.velocity.y);
        _rigidbody.velocity = horizontalMovement;
    }

    private void Jump()
    {
        if (_playerInputReader.IsJumpKeyInputed && _groundDetector.IsGrounded)
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}