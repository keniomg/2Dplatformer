using UnityEngine;

public class PlayerMover : Mover
{
    [SerializeField] private float _jumpForce;

    private PlayerInputReader _playerInputReader;

    public void Initialize(Rigidbody2D rigidbody, PlayerInputReader playerInputReader, Attacker attacker)
    {
        Rigidbody = rigidbody;
        _playerInputReader = playerInputReader;
        Attacker = attacker;
    }

    public void Move()
    {
        ManageDirection();
        Run();
        Jump();
        DoLunge();
    }

    private void ManageDirection()
    {
        if (Rigidbody.velocity.x != 0)
            MoveDirection = Rigidbody.velocity.x > 0 ? Vector2.right : Vector2.left;
    }

    private void Run()
    {
        Vector2 horizontalMovement = new(_playerInputReader.HorizontalAxisValue * Speed, Rigidbody.velocity.y);
        Rigidbody.velocity = horizontalMovement;
    }

    private void Jump()
    {
        if (_playerInputReader.IsJumpInputed)
        {
            Rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
            _playerInputReader.ResetJumpInput();
        }
    }
}