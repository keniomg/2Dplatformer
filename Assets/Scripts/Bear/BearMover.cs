using System.Collections;
using UnityEngine;

public class BearMover : Mover
{
    private WaitForSeconds _waitForSeconds;
    private BearStatus _bearStatus;
    private BearAttacker _bearAttacker;
    private Coroutine _turnCoroutine;

    private void Start()
    {
        float turnDelay = 1;
        _waitForSeconds = new WaitForSeconds(turnDelay);
        MoveDirection = Vector2.right;
    }

    public void Initialize(BearStatus bearStatus, BearAttacker bearAttacker)
    {
        _bearStatus = bearStatus;
        _bearAttacker = bearAttacker;
    }

    public void Move()
    {
        if (!_bearStatus.IsWaiting)
        {
            if (_bearStatus.IsGroundNear)
            {
                _bearStatus.SetRunStatus();

                if (!_bearAttacker.IsAttackRangeEnough && _bearAttacker.Target != null)
                {
                    transform.position = Vector2.MoveTowards(transform.position, _bearAttacker.Target.transform.position, Speed * Time.deltaTime);
                    MoveDirection = _bearAttacker.AttackDirection.x > 0 ? Vector2.right : Vector2.left;
                }
                else
                {
                    transform.Translate(MoveDirection * Speed * Time.deltaTime);
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
            MoveDirection = _bearAttacker.AttackDirection.x > 0 ? Vector2.right : Vector2.left;
            _bearStatus.ResetRunStatus();
        }

        _bearStatus.InitializeMoveDirection(MoveDirection);
    }

    private IEnumerator Turn()
    {
        yield return _waitForSeconds;
        MoveDirection = (MoveDirection == Vector2.right) ? Vector2.left : Vector2.right;
        yield return _waitForSeconds;
        _turnCoroutine = null;
    }
}