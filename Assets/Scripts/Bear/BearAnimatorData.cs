using UnityEngine;

public class BearAnimatorData : MonoBehaviour
{
    public static class Parameters
    {
        public static readonly int IsRun = Animator.StringToHash(nameof(IsRun));
        public static readonly int IsAttack = Animator.StringToHash(nameof(IsAttack));
    }
}