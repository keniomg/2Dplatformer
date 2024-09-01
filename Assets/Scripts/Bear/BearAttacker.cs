using UnityEngine;

public class BearAttacker : Attacker
{
    [SerializeField] private float _attackRadius;

    private BearTargetSearcher _bearSearcher;

    public float AttackRadius => _attackRadius;
    public bool IsWaiting => !CanAttack;

    protected override void Start()
    {
        Mover = TryGetComponent(out BearMover bearMover) ? bearMover : null;
        AnimatorData = TryGetComponent(out AnimatorData animatorData) ? animatorData : null;
        _bearSearcher = TryGetComponent(out BearTargetSearcher bearTargetSearcher) ? bearTargetSearcher : null;
        Searcher = _bearSearcher;

        base.Start();

        AttackDelay = 2;
        WaitAferAttackDelay = new(AttackDelay);
    }

    private void FixedUpdate()
    {
        AttackPlayer();
    }

    private void AttackPlayer()
    {
        if (_bearSearcher.Target != null)
        {
            if (_bearSearcher.DistanceToTarget <= _attackRadius)
            {
                Attack<PlayerHealth>();
            }
        }
    }
}