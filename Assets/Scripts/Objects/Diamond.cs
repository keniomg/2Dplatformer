using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(UnityEngine.Animator))]

public class Diamond : InteractiveObject
{
    public new event Action<Diamond> PickedUp;

    public override void SetPickedUpStatus()
    {
        PickedUp?.Invoke(this);
        Animator.SetBool(DiamondAnimatorData.Parameters.IsPickedUp, true);
    }
}