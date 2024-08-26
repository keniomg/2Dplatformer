using UnityEngine;

public class AnimatorHandler : MonoBehaviour
{
    [SerializeField] protected AnimationClip _attack;
    [SerializeField] protected GameObject _animatingObject;
    [SerializeField] protected StatusHandler _statusHandler;
    [SerializeField] protected Mover _mover;

    protected Rigidbody2D _rigidbody;
    protected Animator _animator;
    protected Vector2 _originalScale;
    protected Vector2 _rightSideDirection;
    protected Vector2 _leftSideDirection;

    protected virtual void Start()
    {
        _originalScale = transform.localScale;
        _rightSideDirection = new(Mathf.Abs(_originalScale.x), _originalScale.y);
        _leftSideDirection = new(-Mathf.Abs(_originalScale.x), _originalScale.y);

        _animator = _animatingObject.TryGetComponent(out Animator animator) ? animator : null;
    }

    protected void Update()
    {
        ManageAnimation();
    }

    public float GetAttackAnimationDuration()
    {
        return _attack.length;
    }

    protected virtual void ManageAnimation()
    {
        UpdateAnimatorParameters();

        transform.localScale = _mover.Direction == Vector2.right ? _rightSideDirection : _leftSideDirection;
    }

    protected virtual void UpdateAnimatorParameters() { }
}