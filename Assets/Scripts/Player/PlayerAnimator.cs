using UnityEngine;

public class PlayerAnimator : ObjectAnimator
{
    private PlayerStatus _playerStatus;

    protected override void Start()
    {
        base.Start();

        _playerStatus = TryGetComponent(out PlayerStatus playerStatus) ? playerStatus : null;
    }

    protected override void UpdateAnimatorParameters()
    {
        if (Animator != null)
        {
            Animator.SetBool(PlayerAnimatorData.Parameters.IsFall, _playerStatus.IsFall);
            Animator.SetBool(PlayerAnimatorData.Parameters.IsJump, _playerStatus.IsJump);
            Animator.SetBool(PlayerAnimatorData.Parameters.IsRun, _playerStatus.IsRun);
            Animator.SetBool(PlayerAnimatorData.Parameters.IsAttack, _playerStatus.IsAttack);
        }
    }
}