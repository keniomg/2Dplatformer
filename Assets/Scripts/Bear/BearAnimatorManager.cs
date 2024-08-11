using UnityEngine;

[RequireComponent(typeof(BearStatusHandler))]
[RequireComponent(typeof(Animator))]

public class BearAnimatorManager : MonoBehaviour
{
    private BearStatusHandler _bearStatusHandler;
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _bearStatusHandler = GetComponent<BearStatusHandler>();
    }

    private void Update()
    {
        ManageAnimationDirection();
    }

    private void ManageAnimationDirection()
    {
        Vector2 originalScale = transform.localScale;
        Vector2 rightSideDirection = new(Mathf.Abs(originalScale.x), originalScale.y);
        Vector2 leftSideDirection = new(-Mathf.Abs(originalScale.x), originalScale.y);

        transform.localScale = _bearStatusHandler.IsMovingRight ? rightSideDirection : leftSideDirection;
        _animator.SetBool(BearAnimatorData.Parameters.IsWaiting, _bearStatusHandler.IsWaiting);
    }
}