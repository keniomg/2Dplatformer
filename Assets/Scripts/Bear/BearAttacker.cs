using UnityEngine;

public class BearAttacker : Attacker
{
    [SerializeField] private float _attackRadius;

    private BearTargetSearcher _bearTargetSearcher;

    public float AttackRadius => _attackRadius;
    public bool IsWaiting => !IsAttackReady;
    public override Vector2 AttackDirection => ManageAttackDirection();
    public bool IsAttackRangeEnough { get; private set; }
    public Health Target { get; private set; }

    protected override void Start()
    {
        base.Start();

        AttackDelay = 2;
        WaitAfterAttackDelay = new(AttackDelay);
    }

    protected Vector2 ManageAttackDirection()
    {
        Vector2 attackDirection = Searcher.Target == null ? Vector2.zero : (Searcher.Target.transform.position - transform.position).normalized;
        return attackDirection;
    }

    public void Initialize(BearAnimatorData animatorData, BearTargetSearcher bearTargetSearcher)
    {
        AnimatorData = (BearAnimatorData)AnimatorData;
        AnimatorData = animatorData;
        _bearTargetSearcher = bearTargetSearcher;
        Searcher = bearTargetSearcher;
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