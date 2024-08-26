using UnityEngine;

public class InteractiveObjectAnimatorData : MonoBehaviour
{
    public static class Parameters
    {
        public static readonly int IsPickedUp = Animator.StringToHash(nameof(IsPickedUp));
    }
}