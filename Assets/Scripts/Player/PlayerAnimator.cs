using UnityEngine;

public class PlayerAnimator : ObjectAnimator
{
    [SerializeField] private PlayerVampirism _playerVampire;
    [SerializeField] private SpriteRenderer _vampireAbilitySprite;

    private PlayerStatus _playerStatus;

    protected override void Start()
    {
        base.Start();

        _vampireAbilitySprite.transform.localScale *= _playerVampire.VampirismRadius;
        _playerStatus = (PlayerStatus)Status;
    }

    public override void ManageAnimation()
    {
        base.ManageAnimation();

        AnimateVampireAbility();
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

    private void AnimateVampireAbility()
    {
        if (_playerVampire.IsAbilityActive && !_vampireAbilitySprite.gameObject.activeSelf)
        {
            _vampireAbilitySprite.gameObject.SetActive(true);
        }
        else if (!_playerVampire.IsAbilityActive)
        {
            _vampireAbilitySprite.gameObject.SetActive(false);
        }
    }
}