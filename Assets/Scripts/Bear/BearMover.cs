using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CapsuleCollider2D), typeof(BearStatusHandler))]
[RequireComponent(typeof(BearAnimatorHandler), typeof(BearAttackHandler), typeof(BearTargetSearcher))]

public class BearMover : Mover
{
    private WaitForSeconds _waitForSeconds;
    private BearStatusHandler _bearStatusHandler;
    private BearAttackHandler _bearAttackHandler;
    private BearTargetSearcher _bearTargetSearcher;
    private Coroutine _turnCoroutine;

    private void Start()
    {
        float turnDelay = 1;
        _waitForSeconds = new WaitForSeconds(turnDelay);
        _bearStatusHandler = GetComponent<BearStatusHandler>();
        _bearAttackHandler = GetComponent<BearAttackHandler>();
        _bearTargetSearcher = GetComponent<BearTargetSearcher>();
        Direction = Vector2.right;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (!_bearAttackHandler.IsWaiting)
        {
            if(_bearStatusHandler.IsGroundNear)
            {
                _bearStatusHandler.SetRunStatus();

                if (_bearTargetSearcher.DistanceToTarget > _bearAttackHandler.AttackRadius)
                {
                    transform.position = Vector2.MoveTowards(transform.position, _bearTargetSearcher.Target.transform.position, _speed * Time.deltaTime);
                    Direction = _bearTargetSearcher.DirectionToTarget.x > 0 ? Vector2.right : Vector2.left;
                }
                else
                {
                    transform.Translate(Direction * _speed * Time.deltaTime);
                }
            }
            else
            {
                _bearStatusHandler.ResetRunStatus();
                _turnCoroutine ??= StartCoroutine(Turn());
            }
        }
        else
        {
            Direction = _bearTargetSearcher.DirectionToTarget.x > 0 ? Vector2.right : Vector2.left;
            _bearStatusHandler.ResetRunStatus();
        }
    }

    private IEnumerator Turn()
    {
        yield return _waitForSeconds;
        Direction = (Direction == Vector2.right) ? Vector2.left : Vector2.right;
        yield return _waitForSeconds;
        _turnCoroutine = null;
    }
}