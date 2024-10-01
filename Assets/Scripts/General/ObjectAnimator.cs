using UnityEngine;

[RequireComponent(typeof(Animator))]

public class ObjectAnimator : MonoBehaviour
{
    protected Animator Animator;
    protected Status Status;
    protected Mover Mover;

    private Vector2 _originalScale;
    private Vector2 _rightSideDirection;
    private Vector2 _leftSideDirection;

    protected virtual void Start()
    {
        _originalScale = transform.localScale;
        _rightSideDirection = new(Mathf.Abs(_originalScale.x), _originalScale.y);
        _leftSideDirection = new(-Mathf.Abs(_originalScale.x), _originalScale.y);
        Animator = TryGetComponent(out Animator animator) ? animator : null;
        Initialize();
    }

    private void Update()
    {
        ManageAnimation();
    }

    public virtual void ManageAnimation()
    {
        UpdateAnimatorParameters();

        transform.localScale = Mover.MoveDirection == Vector2.right ? _rightSideDirection : _leftSideDirection;
    }

    protected virtual void UpdateAnimatorParameters() { }

    private void Initialize()
    {
        if (transform.parent != null)
        {
            Mover = transform.parent.TryGetComponent(out Mover mover) ? mover : null;
            Status = transform.parent.TryGetComponent(out Status status) ? status : null;
        }
    }
}