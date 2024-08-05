using UnityEngine;

public class BearAnimatorData : MonoBehaviour
{
    public static class Parameters
    {
        public static readonly int IsWaiting = Animator.StringToHash(nameof(IsWaiting));
    }
}