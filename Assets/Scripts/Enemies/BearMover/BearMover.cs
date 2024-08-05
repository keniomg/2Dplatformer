using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class BearMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _groundCheckPoint;
    [SerializeField] private LayerMask _ground;

    private Animator _animator;
    private bool _isWaiting;
    private bool _isMovingRight;
    private WaitForSeconds _waitForSeconds;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        float turnDelay = 1;
        _waitForSeconds = new WaitForSeconds(turnDelay);
        _isMovingRight = true;
    }

    private void Update()
    {
        Move();        
    }

    private void Move()
    {
        Vector2 direction;

        if (_isWaiting == false)
        {
            if (_isMovingRight)
            {
                direction = Vector2.right;
            }
            else
            {
                direction = Vector2.left;
            }

            transform.Translate(direction * _speed * Time.deltaTime);
            
            if (GetEdgeNearStatus() == false)
            {
                StartCoroutine(Turn());
            }
        }

        ChangeAnimationDirection();
    }

    private void ChangeAnimationDirection()
    {
        Vector2 originalScale = transform.localScale;
        Vector2 rightSideDirection = new(Mathf.Abs(originalScale.x), originalScale.y);
        Vector2 leftSideDirection = new(-Mathf.Abs(originalScale.x), originalScale.y);

        if (_isMovingRight)
        {
            transform.localScale = rightSideDirection;
        }
        else
        {
            transform.localScale = leftSideDirection;
        }
                
        _animator.SetBool(BearAnimatorData.Parameters.IsWaiting, _isWaiting);
    }

    private bool GetEdgeNearStatus()
    {
        Vector2 checkRayDirection;
        float checkRayDistance = 0.5f;

        if (_isMovingRight)
        {
            checkRayDirection = Vector2.right;
        }
        else
        {
            checkRayDirection= Vector2.left;
        }

        Vector2 groundCheckPosition = (Vector2)_groundCheckPoint.position + checkRayDirection * checkRayDistance;
        RaycastHit2D groundCheckInfo = Physics2D.Raycast(groundCheckPosition, checkRayDirection, checkRayDistance, _ground);
        return groundCheckInfo.collider;
    }

    private IEnumerator Turn()
    {
        _isWaiting = true;
        yield return _waitForSeconds;
        _isMovingRight = !_isMovingRight;
        _isWaiting = false;
    }
}