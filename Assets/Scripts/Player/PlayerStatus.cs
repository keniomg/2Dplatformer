using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerStatus : Status
{
    private Rigidbody2D _rigidbody;
    private PlayerGroundDetector _groundDetector;
    private PlayerInputReader _playerInputReader;
    private PlayerAttacker _playerAttackHandler;

    public bool IsRun => _playerInputReader.HorizontalAxisValue != 0;
    public bool IsFall => !_groundDetector.IsGrounded && _rigidbody.velocity.y < 0;
    public bool IsJump => !_groundDetector.IsGrounded && _rigidbody.velocity.y > 0;
    public bool IsAttack => _playerAttackHandler.IsAttack;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _groundDetector = TryGetComponent(out PlayerGroundDetector groundDetector) ? groundDetector : null;
        _playerInputReader = TryGetComponent(out PlayerInputReader playerInputReader) ? playerInputReader : null;
        _playerAttackHandler = TryGetComponent(out PlayerAttacker playerAttacker) ? playerAttacker : null;
    }
}