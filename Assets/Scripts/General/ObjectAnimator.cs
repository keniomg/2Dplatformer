using UnityEngine;

public class ObjectAnimator : MonoBehaviour
{
    [SerializeField] protected GameObject AnimatingObject;

    protected Animator Animator;

    private Mover _mover;
    private Vector2 _originalScale;
    private Vector2 _rightSideDirection;
    private Vector2 _leftSideDirection;

    protected virtual void Start()
    {
        _originalScale = transform.localScale;
        _rightSideDirection = new(Mathf.Abs(_originalScale.x), _originalScale.y);
        _leftSideDirection = new(-Mathf.Abs(_originalScale.x), _originalScale.y);
        _mover = TryGetComponent(out Mover mover) ? mover : null;

        Animator = AnimatingObject.TryGetComponent(out Animator animator) ? animator : null;
    }

    protected void Update()
    {
        ManageAnimation();
    }

    protected virtual void ManageAnimation()
    {
        UpdateAnimatorParameters();

        transform.localScale = _mover.Direction == Vector2.right ? _rightSideDirection : _leftSideDirection;
    }

    protected virtual void UpdateAnimatorParameters() { }
}