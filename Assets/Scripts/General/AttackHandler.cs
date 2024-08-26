using System;
using System.Collections;
using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    [SerializeField] protected LayerMask _enemy;
    [SerializeField] protected int _attackDamage;
    [SerializeField] protected float _knockbackForce = 120;
    [SerializeField] protected StatusHandler _statusHandler;
    [SerializeField] protected AnimatorHandler _animatorHandler;
    [SerializeField] protected Mover _mover;
    [SerializeField] protected TargetSearcher _targetSearcher;

    protected float _attackDelay;
    protected bool _canAttack;
    protected WaitForSeconds _waitWhileAttack;
    protected WaitForSeconds _waitAferAttackDelay;
    protected Coroutine _cooldownCoroutine;

    public event Action<AttackHandler> DamageDealed;

    public int AttackDamage => _attackDamage;
    public bool IsAttack { get; protected set; }

    protected virtual void Start()
    {
        _cooldownCoroutine = null;
        _canAttack = true;
        _waitWhileAttack = new(_animatorHandler.GetAttackAnimationDuration());
        _attackDelay = 0.5f;
        _waitAferAttackDelay = new(_attackDelay);
    }

    protected virtual void Attack<TargetHealthHandler>() where TargetHealthHandler : HealthHandler
    {
        if (_canAttack)
        {
            TargetHealthHandler targetHealthHandler = (TargetHealthHandler)_targetSearcher.Target;

            if (targetHealthHandler != null)
            {
                targetHealthHandler.InitializeAttackHandler(this);
                DealDamage(targetHealthHandler);
            }

            _cooldownCoroutine ??= StartCoroutine(Cooldown());
        }
    }

    protected void DealDamage(HealthHandler targetHealthHandler)
    {
        DamageDealed?.Invoke(this);

        if (targetHealthHandler.TryGetComponent(out Rigidbody2D rigidbody))
        {
            rigidbody.AddForce(_mover.Direction * _knockbackForce, ForceMode2D.Force);
        }
    }

    protected IEnumerator Cooldown()
    {
        _canAttack = false;
        IsAttack = true;
        yield return _waitWhileAttack;
        IsAttack = false;
        yield return _waitAferAttackDelay;
        _canAttack = true;
        _cooldownCoroutine = null;
    }
}