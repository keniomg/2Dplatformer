using UnityEngine;

public class PlayerStatus : Status
{
    private Rigidbody2D _rigidbody;
    private PlayerGroundDetector _groundDetector;
    private PlayerAttacker _playerAttackHandler;

    public bool IsGrounded => _groundDetector.GetGroundedStatus();
    public bool IsRun => IsGrounded && _rigidbody.velocity.x != 0;
    public bool IsFall => !IsGrounded && _rigidbody.velocity.y < 0;
    public bool IsJump => !IsGrounded && _rigidbody.velocity.y > 0;
    public bool IsAttack => _playerAttackHandler.IsAttack;

    public void Initialize(Rigidbody2D rigidbody, PlayerGroundDetector groundDetector, PlayerAttacker playerAttacker)
    {
        _rigidbody = rigidbody;
        _groundDetector = groundDetector;
        _playerAttackHandler = playerAttacker;
    }
}