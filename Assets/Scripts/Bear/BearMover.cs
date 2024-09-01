using System.Collections;
using UnityEngine;

public class BearMover : Mover
{
    private WaitForSeconds _waitForSeconds;
    private BearStatus _bearStatus;
    private BearAttacker _bearAttacker;
    private BearTargetSearcher _bearTargetSearcher;
    private Coroutine _turnCoroutine;

    private void Start()
    {
        float turnDelay = 1;
        _waitForSeconds = new WaitForSeconds(turnDelay);
        _bearStatus = TryGetComponent(out BearStatus bearStatus) ? bearStatus : null;
        _bearAttacker = TryGetComponent(out BearAttacker bearAttacker) ? bearAttacker : null;
        _bearTargetSearcher = TryGetComponent(out BearTargetSearcher bearTargetSearcher) ? bearTargetSearcher : null;
        Direction = Vector2.right;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (!_bearAttacker.IsWaiting)
        {
            if(_bearStatus.IsGroundNear)
            {
                _bearStatus.SetRunStatus();

                if (_bearTargetSearcher.DistanceToTarget > _bearAttacker.AttackRadius)
                {
                    transform.position = Vector2.MoveTowards(transform.position, _bearTargetSearcher.Target.transform.position, Speed * Time.deltaTime);
                    Direction = _bearTargetSearcher.DirectionToTarget.x > 0 ? Vector2.right : Vector2.left;
                }
                else
                {
                    transform.Translate(Direction * Speed * Time.deltaTime);
                }
            }
            else
            {
                _bearStatus.ResetRunStatus();
                _turnCoroutine ??= StartCoroutine(Turn());
            }
        }
        else
        {
            Direction = _bearTargetSearcher.DirectionToTarget.x > 0 ? Vector2.right : Vector2.left;
            _bearStatus.ResetRunStatus();
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