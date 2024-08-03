using System;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]

public class Diamond : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private Vector2 _originalPosition;

    public event Action<Diamond> PickedUp;

    private void Update()
    {
        RunLevitationAnimation();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMover playerMover))
        {
            _animator.SetBool("isPickedUp", true);
            PickedUp?.Invoke(this);
        }
    }

    public void SetPosition(Vector2 position)
    {
        _originalPosition = position;
    }

    public float GetDisappearAnimationDuration()
    {
        AnimationClip[] clips = _animator.runtimeAnimatorController.animationClips;
        string clipName = "Disappear";

        foreach (AnimationClip clip in clips)
        {
            if (clip.name == clipName)
            {
                return clip.length;
            }
        }

        return 0f;
    }

    private void RunLevitationAnimation()
    {
        float levitationHeight = 0.2f;
        Vector2 animationOffset = new(0,Mathf.Sin(Time.time) * levitationHeight);
        transform.position = _originalPosition + animationOffset;
    }
}