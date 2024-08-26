using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(Animator))]

public class InteractiveObject : MonoBehaviour
{
    [SerializeField] protected AnimationClip _disappear;

    protected Animator _animator;

    public event Action<InteractiveObject> PickedUp;

    protected virtual void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public float GetDisappearAnimationDuration()
    {
        if (_disappear != null)
        {
            return _disappear.length;
        }

        return 0f;
    }

    public virtual void SetPickedUpStatus()
    {
        PickedUp?.Invoke(this);
        _animator.SetBool(InteractiveObjectAnimatorData.Parameters.IsPickedUp, true);
    }
}