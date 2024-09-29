using System.Collections;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] protected float Speed;

    protected float LungeForce = 50f;
    protected Rigidbody2D Rigidbody;
    protected WaitForSeconds WaitForAttack;
    protected Attacker Attacker;
    protected Coroutine LungeCoroutine;

    public Vector2 MoveDirection { get; protected set; }

    protected virtual void Start()
    {
        WaitForAttack = new(Attacker.GetAttackAnimationDuration());
    }

    protected void DoLunge()
    {
        if (Attacker.IsAttack && LungeCoroutine == null)
        {
            LungeCoroutine = StartCoroutine(Lunge());
        }
    }

    protected IEnumerator Lunge()
    {
        Rigidbody.AddForce(MoveDirection * LungeForce, ForceMode2D.Impulse);
        yield return WaitForAttack;
        LungeCoroutine = null;
    }
}