using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(PlayerStatusHandler))]
[RequireComponent(typeof(PlayerAnimatorManager))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private PlayerStatusHandler _playerStatusHandler;
    private Rigidbody2D _rigidbody;

    public float HorizontalAxisValue { get; private set; }

    private void Start()
    {
        _playerStatusHandler = GetComponent<PlayerStatusHandler>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
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
        HorizontalAxisValue = Input.GetAxis("Horizontal");
        Vector2 horizontalMovement = new(HorizontalAxisValue * _speed, _rigidbody.velocity.y);
        _rigidbody.velocity = horizontalMovement;
    }

    private void Jump()
    {
        KeyCode jumpKey = KeyCode.Space;
        bool _isGrounded = _playerStatusHandler.IsGrounded;

        if (Input.GetKeyDown(jumpKey) && _isGrounded)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }
}