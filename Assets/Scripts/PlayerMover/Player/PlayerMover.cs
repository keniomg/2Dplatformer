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

    private bool _isFall;
    private bool _isJump;
    private bool _isRun;
    private Animator _animator;
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
    
    private void UpdateAnimatorParameters()
    {
        _animator.SetBool(PlayerAnimatorData.Parameters.IsFall, _isFall);
        _animator.SetBool(PlayerAnimatorData.Parameters.IsJump, _isJump);
        _animator.SetBool(PlayerAnimatorData.Parameters.IsRun, _isRun);
    }

    private void Move()
    {
        UpdateAnimatorParameters();
        Run();
        Jump();
    }

    private void Run()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector2 horizontalMovement = new(horizontal * _speed, _rigidbody.velocity.y);
        _rigidbody.velocity = horizontalMovement;
        ChangeAnimationDirection(horizontal);
        ManageRunStatus(horizontal);
    }

    private void ManageRunStatus(float axisValue)
    {
        if (axisValue != 0)
        {
            _isRun = true;
        }
        else
        {
            _isRun = false;
        }
    }

    private void ChangeAnimationDirection(float axisValue)
    {
        Vector2 originalScale = transform.localScale;
        Vector2 rightSideDirection = new(Mathf.Abs(originalScale.x), originalScale.y);
        Vector2 leftSideDirection = new(-Mathf.Abs(originalScale.x), originalScale.y);

        if (axisValue > 0)
        {
            transform.localScale = rightSideDirection;
        }
        else if (axisValue < 0)
        {
            transform.localScale = leftSideDirection;
        }
    }

    private void Jump()
    {
        KeyCode jumpKey = KeyCode.Space;
        bool isGrounded = GetGroundedStatus();
        ManageFallAndJumpStatus(isGrounded);

        if (Input.GetKeyDown(jumpKey) && isGrounded)
        {
            _rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private bool GetGroundedStatus()
    {
        float checkRadius = 0.1f;
        bool isGrounded = Physics2D.OverlapCircle(_groundCheckPoint.position, checkRadius, _ground);
        return isGrounded;
    }

    private void ManageFallAndJumpStatus(bool isGrounded)
    {
        if (isGrounded == false)
        {
            if (_rigidbody.velocity.y > 0)
            {
                _isJump = true;
                _isFall = false;
            }
            else if (_rigidbody.velocity.y < 0)
            {
                _isJump = false;
                _isFall = true;
            }
        }
        else
        {
            _isJump = false;
            _isFall = false;
        }
    }
}