using UnityEngine;

[RequireComponent(typeof(BearTargetSearcher), typeof(BearAnimatorData), typeof(BearAttacker))]
[RequireComponent(typeof(BearGroundDetector), typeof(BearHealth), typeof(BearMover))]
[RequireComponent(typeof(BearStatus))]

[RequireComponent(typeof(Rigidbody2D))]

public class Bear : MonoBehaviour 
{
    private BearTargetSearcher _targetSearcher;
    private BearGroundDetector _groundDetector;
    private BearAnimatorData _animatorData;
    private BearAttacker _attacker;
    private BearHealth _health;
    private BearStatus _status;
    private BearMover _mover;

    private Rigidbody2D _rigidbody;

    private void Awake()
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
        _attacker.ManageAttackParameters();
        _targetSearcher.InitializeTarget<PlayerHealth>();
    }

    private void GetAllBearComponents()
    {
        _targetSearcher = GetComponent<BearTargetSearcher>();
        _groundDetector = GetComponent<BearGroundDetector>();
        _animatorData = GetComponent<BearAnimatorData>();
        _attacker = GetComponent<BearAttacker>();
        _health = GetComponent<BearHealth>();
        _status = GetComponent<BearStatus>();
        _mover = GetComponent<BearMover>();
    }

    private void InitializeAll()
    {
        _attacker.Initialize(_animatorData, _targetSearcher);
        _status.Initialize(_groundDetector, _attacker);
        _mover.Initialize(_status, _attacker, _rigidbody);
    }
}