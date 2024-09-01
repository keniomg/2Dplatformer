using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(Animator))]

public class InteractiveObject : MonoBehaviour
{
    [SerializeField] protected AnimationClip Disappear;

    protected Animator Animator;

    public event Action<InteractiveObject> PickedUp;

    protected virtual void Start()
    {
        Animator = GetComponent<Animator>();
    }

    public float GetDisappearAnimationDuration()
    {
        if (Disappear != null)
        {
            return Disappear.length;
        }

        return 0f;
    }

    public virtual void SetPickedUpStatus()
    {
        PickedUp?.Invoke(this);
        Animator.SetBool(InteractiveObjectAnimatorData.Parameters.IsPickedUp, true);
    }
}