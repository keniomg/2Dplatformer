using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Animator))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _groundCheckPoint;
    [SerializeField] private LayerMask _ground;
    [SerializeField] private Animator _animator;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
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
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 horizontalMovement = new(horizontal * _speed, _rigidbody.velocity.y);
        _rigidbody.velocity = horizontalMovement;
        ChangeAnimationDirection(horizontal);

        if (horizontal != 0)
        {
            _animator.SetBool("isRun", true);
        }
        else
        {
            _animator.SetBool("isRun", false);
        }
    }

    private void ChangeAnimationDirection(float getAxisInputValue)
    {
        Vector2 originalScale = transform.localScale;
        Vector2 rightSideDirection = new(Mathf.Abs(originalScale.x), originalScale.y);
        Vector2 leftSideDirection = new(-Mathf.Abs(originalScale.x), originalScale.y);

        if (getAxisInputValue > 0)
        {
            transform.localScale = rightSideDirection;
        }
        else if (getAxisInputValue < 0)
        {
            transform.localScale = leftSideDirection;
        }
    }

    private void Jump()
    {
        KeyCode jumpKey = KeyCode.Space;
        CheckGrounded(out bool isGrounded);

        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void CheckGrounded(out bool isGrounded)
    {
        float checkRadius = 0.1f;

        isGrounded = Physics2D.OverlapCircle(_groundCheckPoint.position, checkRadius, _ground);

        if (isGrounded == false)
        {
            if (_rigidbody.velocity.y > 0)
            {
                _animator.SetBool("isJump", true);
                _animator.SetBool("isFall", false);
            }
            else if (_rigidbody.velocity.y < 0)
            {
                _animator.SetBool("isJump", false);
                _animator.SetBool("isFall", true);
            }
        }
        else
        {
            _animator.SetBool("isJump", false);
            _animator.SetBool("isFall", false);
        }
    }
}