using System.Collections;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] protected int AttackDamage;
    [SerializeField] protected float KnockbackForce;
    
    protected AnimatorData AnimatorData;
    protected TargetSearcher Searcher;
    protected Mover Mover;
    protected float AttackDelay;
    protected bool CanAttack;
    protected WaitForSeconds WaitWhileAttack;
    protected WaitForSeconds WaitAferAttackDelay;
    protected Coroutine CooldownCoroutine;

    public bool IsAttack { get; protected set; }

    protected virtual void Start()
    {
        CooldownCoroutine = null;
        CanAttack = true;
        WaitWhileAttack = new(AnimatorData.GetAttackAnimationDuration());
        AttackDelay = 0.5f;
        WaitAferAttackDelay = new(AttackDelay);
    }

    protected virtual void Attack<TargetHealthHandler>() where TargetHealthHandler : Health
    {
        if (CanAttack)
        {
            TargetHealthHandler targetHealthHandler = (TargetHealthHandler)Searcher.Target;

            if (targetHealthHandler != null)
            {
                DealDamage(targetHealthHandler);
            }

            CooldownCoroutine ??= StartCoroutine(Cooldown());
        }
    }

    protected void DealDamage(Health targetHealthHandler)
    {
        targetHealthHandler.DecreaseHealth(AttackDamage);

        if (targetHealthHandler.TryGetComponent(out Rigidbody2D rigidbody))
        {
            rigidbody.AddForce(Searcher.DirectionToTarget * KnockbackForce, ForceMode2D.Force);
        }
    }

    protected IEnumerator Cooldown()
    {
        CanAttack = false;
        IsAttack = true;
        yield return WaitWhileAttack;
        IsAttack = false;
        yield return WaitAferAttackDelay;
        CanAttack = true;
        CooldownCoroutine = null;
    }
}