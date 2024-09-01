public class BearAnimator : ObjectAnimator
{
    private BearStatus _bearStatus;

    protected override void Start()
    {
        base.Start();

        _bearStatus = TryGetComponent(out BearStatus bearStatus) ? bearStatus : null;
    }

    protected override void UpdateAnimatorParameters()
    {
        Animator.SetBool(BearAnimatorData.Parameters.IsRun, _bearStatus.IsRun);
        Animator.SetBool(BearAnimatorData.Parameters.IsAttack, _bearStatus.IsAttack);
    }
}