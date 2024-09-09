using UnityEngine;

public class ObjectAnimator : MonoBehaviour
{
    [SerializeField] protected GameObject AnimatingObject;

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

        Animator = AnimatingObject.TryGetComponent(out Animator animator) ? animator : null;
    }

    public void Initialize(Mover mover, Status status)
    {
        Mover = mover;
        Status = status;
    }

    public void ManageAnimation()
    {
        UpdateAnimatorParameters();

        transform.localScale = Mover.MoveDirection == Vector2.right ? _rightSideDirection : _leftSideDirection;
    }

    protected virtual void UpdateAnimatorParameters() { }
}