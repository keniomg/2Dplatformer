using UnityEngine;

[RequireComponent(typeof(PlayerGroundDetector), typeof(PlayerAnimatorData), typeof(PlayerTargetSearcher))]
[RequireComponent(typeof(PlayerAttacker), typeof(PlayerCollider), typeof(PlayerHealth))]
[RequireComponent(typeof(PlayerInputReader), typeof(PlayerMover), typeof(PlayerStatus))]
//[RequireComponent(typeof(PlayerVampire), typeof(VampirismTargetSearcher))]

[RequireComponent(typeof(Rigidbody2D))]

public class Player : MonoBehaviour 
{
    private PlayerTargetSearcher _targetSearcher;
    private PlayerGroundDetector _groundDetector;
    private PlayerAnimatorData _animatorData;
    private PlayerInputReader _inputReader;
    private PlayerCollider _collider;
    private PlayerAttacker _attacker;
    private PlayerHealth _health;
    private PlayerStatus _status;
    private PlayerMover _mover;

    //private PlayerVampire _playerVampire;
    //private VampirismTargetSearcher _vampirismTargetSearcher;

    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        GetAllPlayerComponents();
        InitializeAll();
    }

    private void FixedUpdate()
    {
        _attacker.AttackWithInput();
        _mover.Move();
    }

    private void Update()
    {
        _inputReader.HandleInput();
    }

    private void GetAllPlayerComponents()
    {
        _targetSearcher = GetComponent<PlayerTargetSearcher>();
        _groundDetector = GetComponent<PlayerGroundDetector>();
        _animatorData = GetComponent<PlayerAnimatorData>();
        _inputReader = GetComponent<PlayerInputReader>();
        _collider = GetComponent<PlayerCollider>();
        _attacker = GetComponent<PlayerAttacker>();
        _health = GetComponent<PlayerHealth>();
        _status = GetComponent<PlayerStatus>();
        _mover = GetComponent<PlayerMover>();

        //_playerVampire = GetComponent<PlayerVampire>();
        //_vampirismTargetSearcher = GetComponent<VampirismTargetSearcher>();
    }

    private void InitializeAll()
    {
        _attacker.Initialize(_inputReader, _animatorData, _targetSearcher, _mover);
        _status.Initialize(_rigidbody, _groundDetector, _attacker);
        _mover.Initialize(_rigidbody, _inputReader, _attacker);
        _targetSearcher.Initialize(_mover);
        _inputReader.Initialize(_status);
        _collider.Initialize(_health);

        //_playerVampire.Initialize(_health, _vampirismTargetSearcher);
        //_vampirismPlayerUI.Initialize(_playerVampire);
    }
}