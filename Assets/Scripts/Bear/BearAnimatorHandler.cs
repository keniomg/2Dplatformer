public class BearAnimatorHandler : AnimatorHandler
{
    private BearStatusHandler _bearStatusHandler;

    protected override void Start()
    {
        base.Start();

        _bearStatusHandler = (BearStatusHandler)_statusHandler;
    }

    protected override void UpdateAnimatorParameters()
    {
        _animator.SetBool(BearAnimatorData.Parameters.IsRun, _bearStatusHandler.IsRun);
        _animator.SetBool(BearAnimatorData.Parameters.IsAttack, _bearStatusHandler.IsAttack);
    }
}