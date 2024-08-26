using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerMover), typeof(PlayerHealthHandler))]
[RequireComponent(typeof(PlayerAttackHandler))]

public class PlayerStatusHandler : StatusHandler
{
    private Rigidbody2D _rigidbody;
    private GroundDetector _groundDetector;
    private PlayerInputReader _playerInputReader;
    private PlayerAttackHandler _playerAttackHandler;

    public bool IsRun => _playerInputReader.HorizontalAxisValue != 0;
    public bool IsFall => !_groundDetector.IsGrounded && _rigidbody.velocity.y < 0;
    public bool IsJump => !_groundDetector.IsGrounded && _rigidbody.velocity.y > 0;
    public bool IsAttack => _playerAttackHandler.IsAttack;

    private void Start()
    {
        _groundDetector = GetComponent<GroundDetector>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerInputReader = GetComponent<PlayerInputReader>();
        _playerAttackHandler = GetComponent<PlayerAttackHandler>();
    }
}