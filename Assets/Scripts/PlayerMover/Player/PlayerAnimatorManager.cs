using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerStatusHandler))]
[RequireComponent(typeof(PlayerMover))]

public class PlayerAnimatorManager : MonoBehaviour
{
    private Animator _animator;
    private PlayerStatusHandler _playerStatusHandler;
    private PlayerMover _playerMover;

    private void Start()
    {
        _playerMover = GetComponent<PlayerMover>();
        _playerStatusHandler = GetComponent<PlayerStatusHandler>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        ManageAnimation();
    }

    private void ManageAnimation()
    {
        UpdateAnimatorParameters();
        ChangeAnimationDirection();
    }

    private void UpdateAnimatorParameters()
    {
        _animator.SetBool(PlayerAnimatorData.Parameters.IsFall, _playerStatusHandler.IsFall);
        _animator.SetBool(PlayerAnimatorData.Parameters.IsJump, _playerStatusHandler.IsJump);
        _animator.SetBool(PlayerAnimatorData.Parameters.IsRun, _playerStatusHandler.IsRun);
    }

    private void ChangeAnimationDirection()
    {
        Vector2 originalScale = transform.localScale;
        Vector2 rightSideDirection = new(Mathf.Abs(originalScale.x), originalScale.y);
        Vector2 leftSideDirection = new(-Mathf.Abs(originalScale.x), originalScale.y);

        if (_playerMover.HorizontalAxisValue > 0)
        {
            transform.localScale = rightSideDirection;
        }
        else if (_playerMover.HorizontalAxisValue < 0)
        {
            transform.localScale = leftSideDirection;
        }
    }
}