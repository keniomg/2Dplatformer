public class PlayerAnimatorHandler : AnimatorHandler
{
    private PlayerStatusHandler _playerStatusHandler;

    protected override void Start()
    {
        base.Start();

        _playerStatusHandler = (PlayerStatusHandler)_statusHandler;
    }

    protected override void UpdateAnimatorParameters()
    {
        if (_animator != null)
        {
            _animator.SetBool(PlayerAnimatorData.Parameters.IsFall, _playerStatusHandler.IsFall);
            _animator.SetBool(PlayerAnimatorData.Parameters.IsJump, _playerStatusHandler.IsJump);
            _animator.SetBool(PlayerAnimatorData.Parameters.IsRun, _playerStatusHandler.IsRun);
            _animator.SetBool(PlayerAnimatorData.Parameters.IsAttack, _playerStatusHandler.IsAttack);
        }
    }
}