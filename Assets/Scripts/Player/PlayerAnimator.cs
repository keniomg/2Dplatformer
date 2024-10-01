using UnityEngine;

public class PlayerAnimator : ObjectAnimator
{
    //[SerializeField] private PlayerVampire _playerVampire;
    [SerializeField] private SpriteRenderer _spriteRenderer;

    private PlayerStatus _playerStatus;

    protected override void Start()
    {
        base.Start();

        //_spriteRenderer.transform.localScale *= _playerVampire.VampirismRadius;
        _playerStatus = (PlayerStatus)Status;
    }

    public override void ManageAnimation()
    {
        base.ManageAnimation();

        //AnimateVampireAbility();
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

    //private void AnimateVampireAbility()
    //{
    //    if (_playerVampire.IsAbilityActive)
    //    {
    //        _spriteRenderer.gameObject.SetActive(true);
    //    }
    //    else
    //    {
    //        _spriteRenderer.gameObject.SetActive(false);
    //    }
    //}
}