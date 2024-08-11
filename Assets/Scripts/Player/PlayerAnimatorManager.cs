using UnityEngine;

[RequireComponent(typeof(Animator), typeof(PlayerStatusHandler), typeof(PlayerMover))]

public class PlayerAnimatorManager : MonoBehaviour
{
    private Animator _animator;
    private PlayerStatusHandler _playerStatusHandler;
    private PlayerInputReader _playerInputReader;
    private Vector2 _rightSideDirection;
    private Vector2 _leftSideDirection;
    private Vector2 _originalScale;

    private void Start()
    {
        _originalScale = transform.localScale;
        _rightSideDirection = new(Mathf.Abs(_originalScale.x), _originalScale.y);
        _leftSideDirection = new(-Mathf.Abs(_originalScale.x), _originalScale.y);

        _playerStatusHandler = GetComponent<PlayerStatusHandler>();
        _playerInputReader = GetComponent<PlayerInputReader>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        ManageAnimation();
    }

    private void ManageAnimation()
    {
        UpdateAnimatorParameters();

        if (_playerInputReader.HorizontalAxisValue != 0)
        {
            transform.localScale = _playerInputReader.HorizontalAxisValue > 0 ? _rightSideDirection : _leftSideDirection;
        }
    }

    private void UpdateAnimatorParameters()
    {
        _animator.SetBool(PlayerAnimatorData.Parameters.IsFall, _playerStatusHandler.IsFall);
        _animator.SetBool(PlayerAnimatorData.Parameters.IsJump, _playerStatusHandler.IsJump);
        _animator.SetBool(PlayerAnimatorData.Parameters.IsRun, _playerStatusHandler.IsRun);
    }
}