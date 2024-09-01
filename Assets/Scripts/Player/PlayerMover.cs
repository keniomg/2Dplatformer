using UnityEngine;

public class PlayerMover : Mover
{
    [SerializeField] private float _jumpForce;

    private PlayerGroundDetector _groundDetector;
    private Rigidbody2D _rigidbody;
    private PlayerInputReader _playerInputReader;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _groundDetector = TryGetComponent(out PlayerGroundDetector groundDetector) ? groundDetector : null;
        _playerInputReader = TryGetComponent(out PlayerInputReader playerInputReader) ? playerInputReader : null;
    }

    private void FixedUpdate()
    {
        ManageDirection();
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
        Vector2 horizontalMovement = new(_playerInputReader.HorizontalAxisValue * Speed, _rigidbody.velocity.y);
        _rigidbody.velocity = horizontalMovement;
    }

    private void Jump()
    {
        if (_playerInputReader.IsJumpKeyInputed && _groundDetector.IsGrounded)
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}