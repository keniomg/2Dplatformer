using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(Animator))]

public class Diamond : MonoBehaviour
{
    [SerializeField] private AnimationClip _disappearClip;

    private Animator _animator;

    public event Action<Diamond> PickedUp;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public float GetDisappearAnimationDuration()
    {
        if (_disappearClip != null)
        {
            return _disappearClip.length;
        }

        return 0f;
    }

    public void SetPickedUpStatus()
    {
        PickedUp?.Invoke(this);
        _animator.SetBool(DiamondAnimatorData.Parameters.IsPickedUp, true);
    }
}