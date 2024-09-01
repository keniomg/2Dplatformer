using UnityEngine;

public class PlayerAnimatorData : AnimatorData
{
    public static new class Parameters
    {
        public static readonly int IsFall = Animator.StringToHash(nameof(IsFall));
        public static readonly int IsJump = Animator.StringToHash(nameof(IsJump));
        public static readonly int IsRun = Animator.StringToHash(nameof(IsRun));
        public static readonly int IsAttack = Animator.StringToHash(nameof(IsAttack));
    }
}