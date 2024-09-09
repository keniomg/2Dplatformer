using UnityEngine;

public class BearAttacker : Attacker
{
    [SerializeField] private float _attackRadius;

    private BearTargetSearcher _bearTargetSearcher;

    public float AttackRadius => _attackRadius;
    public bool IsWaiting => !IsAttackReady;
    public bool IsAttackRangeEnough {get; private set; }
    public Health Target {get; private set; }

    protected override void Start()
    {
        base.Start();

        AttackDelay = 2;
        WaitAferAttackDelay = new(AttackDelay);
    }

    public void Initialize(BearAnimatorData animatorData, BearTargetSearcher bearTargetSearcher)
    {
        AnimatorData = (BearAnimatorData)AnimatorData;
        AnimatorData = animatorData;
        _bearTargetSearcher = bearTargetSearcher;
        Searcher = _bearTargetSearcher;
    }

    public void ManageAttackParameters()
    {
        Target = _bearTargetSearcher.Target;
        IsAttackRangeEnough = (_bearTargetSearcher.DistanceToTarget <= _attackRadius);
    }

    public void AttackPlayer()
    {
        if (_bearTargetSearcher.Target != null)
        {
            if (IsAttackRangeEnough && _bearTargetSearcher.DistanceToTarget != 0)
            {
                Attack<PlayerHealth>();
            }
        }
    }
}