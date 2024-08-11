using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerMover))]

public class PlayerStatusHandler : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private GroundDetector _groundDetector;
    private PlayerInputReader _playerInputReader;

    public bool IsRun => _playerInputReader.HorizontalAxisValue != 0;
    public bool IsFall => !_groundDetector.IsGrounded && _rigidbody.velocity.y < 0;
    public bool IsJump => !_groundDetector.IsGrounded && _rigidbody.velocity.y > 0;

    private void Start()
    {
        _groundDetector = GetComponent<GroundDetector>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerInputReader = GetComponent<PlayerInputReader>();
    }
}