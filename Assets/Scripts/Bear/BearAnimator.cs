public class BearAnimator : ObjectAnimator
{
    private BearStatus _bearStatus;

    protected override void Start()
    {
        base.Start();

        _bearStatus = (BearStatus)Status;
    }

    protected override void UpdateAnimatorParameters()
    {
        Animator.SetBool(BearAnimatorData.Parameters.IsRun, _bearStatus.IsRun);
        Animator.SetBool(BearAnimatorData.Parameters.IsAttack, _bearStatus.IsAttack);
    }
}