using UnityEngine;

public class DiamondAnimatorData : MonoBehaviour
{
    public static class Parameters
    {
        public static readonly int IsPickedUp = Animator.StringToHash(nameof(IsPickedUp));
    }
}