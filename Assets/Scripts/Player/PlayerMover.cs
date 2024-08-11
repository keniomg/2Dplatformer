using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CapsuleCollider2D), typeof(PlayerStatusHandler))]
[RequireComponent(typeof(PlayerAnimatorManager), typeof(PlayerInputReader), typeof(GroundDetector))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private GroundDetector _groundDetector;
    private Rigidbody2D _rigidbody;
    private PlayerInputReader _playerInputReader;
    private float _horizontalAxisValue;
    private bool _isJumpKeyInputed;

    private void Start()
    {
        _groundDetector = GetComponent<GroundDetector>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerInputReader = GetComponent<PlayerInputReader>();
    }

    private void Update()
    {
        _horizontalAxisValue = _playerInputReader.HorizontalAxisValue;
        _isJumpKeyInputed = _playerInputReader.IsJumpKeyInputed;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Run();
        Jump();
    }

    private void Run()
    {
        Vector2 horizontalMovement = new(_horizontalAxisValue * _speed, _rigidbody.velocity.y);
        _rigidbody.velocity = horizontalMovement;
    }

    private void Jump()
    {
        if (_isJumpKeyInputed && _groundDetector.IsGrounded)
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
    }
}