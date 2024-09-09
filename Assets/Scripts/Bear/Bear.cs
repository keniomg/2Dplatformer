using UnityEngine;

[RequireComponent(typeof(BearAnimator), typeof(BearAnimatorData), typeof(BearAttacker))]
[RequireComponent(typeof(BearGroundDetector), typeof(BearHealth), typeof(BearMover))]
[RequireComponent(typeof(BearStatus), typeof(BearTargetSearcher))]

[RequireComponent(typeof(Rigidbody2D))]

public class Bear : MonoBehaviour 
{
    private BearTargetSearcher _targetSearcher;
    private BearGroundDetector _groundDetector;
    private BearAnimatorData _animatorData;
    private BearAnimator _bearAnimator;
    private BearAttacker _attacker;
    private BearHealth _health;
    private BearStatus _status;
    private BearMover _mover;

    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        GetAllBearComponents();
        InitializeAll();
    }

    private void FixedUpdate()
    {
        _mover.Move();
        _attacker.AttackPlayer();
    }

    private void Update()
    {
        _bearAnimator.ManageAnimation();
        _attacker.ManageAttackParameters();
        _targetSearcher.InititalizeTarget();
    }

    private void GetAllBearComponents()
    {
        _targetSearcher = GetComponent<BearTargetSearcher>();
        _groundDetector = GetComponent<BearGroundDetector>();
        _animatorData = GetComponent<BearAnimatorData>();
        _bearAnimator = GetComponent<BearAnimator>();
        _attacker = GetComponent<BearAttacker>();
        _health = GetComponent<BearHealth>();
        _status = GetComponent<BearStatus>();
        _mover = GetComponent<BearMover>();
    }

    private void InitializeAll()
    {
        _attacker.Initialize(_animatorData, _targetSearcher);
        _status.Initialize(_groundDetector, _attacker);
        _mover.Initialize(_status, _attacker);
        _bearAnimator.Initialize(_mover, _status);
    }
}