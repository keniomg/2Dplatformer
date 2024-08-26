using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(Animator))]

public class Cherry : InteractiveObject
{
    public new event Action<Cherry> PickedUp;

    public int HealingValue {get; private set; }

    protected override void Start()
    {
        base.Start();
        HealingValue = 25;
    }

    public override void SetPickedUpStatus()
    {
        PickedUp?.Invoke(this);
        _animator.SetBool(CherryAnimatorData.Parameters.IsPickedUp, true);
    }
}