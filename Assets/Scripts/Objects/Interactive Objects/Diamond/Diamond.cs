using System;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class Diamond : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private bool _isPickedUp;

    public event Action PickedUp;

    private void Update()
    {
        ManageAnimator();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerMover playerMover))
        {
            PickedUp?.Invoke();
            _isPickedUp = true;
        }
    }

    public void ResetPickedUpStatus()
    {
        _isPickedUp = false;
    }

    public float GetAnimationDuration(string clipName)
    {
        AnimationClip[] clips = _animator.runtimeAnimatorController.animationClips;

        foreach (AnimationClip clip in clips)
        {
            if (clip.name == clipName)
            {
                return clip.length;
            }
        }

        return 0f;
    }

    private void ManageAnimator()
    {
        if (_isPickedUp)
        {
            _animator.SetTrigger("isPickedUp");
        }
        else
        {
            _animator.ResetTrigger("isPickedUp");
        }
    }
}