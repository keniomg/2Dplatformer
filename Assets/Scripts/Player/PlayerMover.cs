using UnityEngine;

public class PlayerMover : Mover
{
    [SerializeField] private float _jumpForce;

    private Rigidbody2D _rigidbody;
    private PlayerInputReader _playerInputReader;

    public void Initialize(Rigidbody2D rigidbody, PlayerInputReader playerInputReader)
    {
        _rigidbody = rigidbody;
        _playerInputReader = playerInputReader;
    }

    public void Move()
    {
        ManageDirection();
        Run();
        Jump();
    }

    private void ManageDirection()
    {
        if (_rigidbody.velocity.x != 0)
            MoveDirection = _rigidbody.velocity.x > 0 ? Vector2.right : Vector2.left;
    }

    private void Run()
    {
        Vector2 horizontalMovement = new(_playerInputReader.HorizontalAxisValue * Speed, _rigidbody.velocity.y);
        _rigidbody.velocity = horizontalMovement;
    }

    private void Jump()
    {
        if (_playerInputReader.IsJumpInputed)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _playerInputReader.ResetJumpInput();
        }
    }
}