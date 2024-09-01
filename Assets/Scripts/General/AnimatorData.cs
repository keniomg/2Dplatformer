using UnityEngine;

public class AnimatorData : MonoBehaviour
{
    [SerializeField] protected AnimationClip Attack;

    public static class Parameters
    {
        public static readonly int IsRun = Animator.StringToHash(nameof(IsRun));
        public static readonly int IsAttack = Animator.StringToHash(nameof(IsAttack));
    }

    public float GetAttackAnimationDuration()
    {
        return Attack.length;
    }
}