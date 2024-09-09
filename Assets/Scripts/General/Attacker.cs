using System.Collections;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] protected int AttackDamage;
    [SerializeField] protected float KnockbackForce;
    [SerializeField] protected AnimationClip AttackClip;

    protected AnimatorData AnimatorData;
    protected TargetSearcher Searcher;
    protected float AttackDelay;
    protected bool IsAttackReady;
    protected WaitForSeconds WaitWhileAttack;
    protected WaitForSeconds WaitAferAttackDelay;
    protected Coroutine CooldownCoroutine;

    public bool IsAttack { get; protected set; }
    public Vector2 AttackDirection => ManageAttackDirection();

    protected virtual void Start()
    {
        CooldownCoroutine = null;
        IsAttackReady = true;
        WaitWhileAttack = new(GetAttackAnimationDuration());
        AttackDelay = 0.5f;
        WaitAferAttackDelay = new(AttackDelay);
    }

    protected virtual void Attack<TargetHealthHandler>() where TargetHealthHandler : Health
    {
        if (IsAttackReady)
        {
            TargetHealthHandler targetHealthHandler = (TargetHealthHandler)Searcher.Target;

            if (targetHealthHandler != null)
            {
                DealDamage(targetHealthHandler);
            }

            CooldownCoroutine ??= StartCoroutine(Cooldown());
        }
    }

    protected Vector2 ManageAttackDirection()
    {
        Vector2 attackDirection = Searcher.Target == null ? Vector2.zero : (Searcher.Target.transform.position - transform.position).normalized;
        return attackDirection;
    }

    protected void DealDamage(Health targetHealthHandler)
    {
        targetHealthHandler.DecreaseHealth(AttackDamage);

        if (targetHealthHandler.TryGetComponent(out Rigidbody2D rigidbody))
        {
            rigidbody.AddForce(AttackDirection * KnockbackForce, ForceMode2D.Force);
        }
    }

    public float GetAttackAnimationDuration()
    {
        return AttackClip.length;
    }

    protected IEnumerator Cooldown()
    {
        IsAttackReady = false;
        IsAttack = true;
        yield return WaitWhileAttack;
        IsAttack = false;
        yield return WaitAferAttackDelay;
        IsAttackReady = true;
        CooldownCoroutine = null;
    }
}