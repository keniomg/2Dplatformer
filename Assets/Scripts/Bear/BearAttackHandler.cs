using UnityEngine;

[RequireComponent(typeof(BearMover), typeof(BearTargetSearcher))]

public class BearAttackHandler : AttackHandler
{
    [SerializeField] private float _attackRadius;

    private BearTargetSearcher _bearTargetSearcher;

    public float AttackRadius => _attackRadius;
    public bool IsWaiting => !_canAttack;

    protected override void Start()
    {
        base.Start();
        _attackDelay = 2;
        _waitAferAttackDelay = new(_attackDelay);
        _bearTargetSearcher = GetComponent<BearTargetSearcher>();
    }

    private void FixedUpdate()
    {
        AttackPlayer();
    }

    private void AttackPlayer()
    {
        if (_bearTargetSearcher.Target != null)
        {
            if (_bearTargetSearcher.DistanceToTarget <= _attackRadius)
            {
                Attack<PlayerHealthHandler>();
            }
        }
    }
}