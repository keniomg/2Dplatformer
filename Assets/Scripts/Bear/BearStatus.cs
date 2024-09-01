public class BearStatus : Status
{
    private BearGroundDetector _bearGroundDetector;
    private BearAttacker _bearAttack;

    public bool IsRun { get; private set; }
    public bool IsGroundNear => _bearGroundDetector.GetGroundNearStatus();
    public bool IsAttack => _bearAttack.IsAttack;

    private void Start()
    {
        _bearGroundDetector = TryGetComponent(out BearGroundDetector bearGroundDetector) ? bearGroundDetector : null;
        _bearAttack = TryGetComponent(out BearAttacker bearAttacker) ? bearAttacker : null;
    }

    public void SetRunStatus()
    {
        IsRun = true;
    }

    public void ResetRunStatus()
    {
        IsRun = false;
    }
}