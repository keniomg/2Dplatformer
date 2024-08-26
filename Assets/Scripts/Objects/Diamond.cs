using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(Animator))]

public class Diamond : InteractiveObject
{
    public new event Action<Diamond> PickedUp;

    public override void SetPickedUpStatus()
    {
        PickedUp?.Invoke(this);
        _animator.SetBool(DiamondAnimatorData.Parameters.IsPickedUp, true);
    }
}