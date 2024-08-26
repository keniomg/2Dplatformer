using UnityEngine;

[RequireComponent(typeof(PlayerInputReader), typeof(PlayerAnimatorHandler), typeof(PlayerTargetSearcher))]

public class PlayerAttackHandler : AttackHandler
{
    private PlayerInputReader _playerInputReader;

    protected override void Start()
    {
        base.Start();
        _playerInputReader = GetComponent<PlayerInputReader>();
    }

    private void FixedUpdate()
    {
        AttackWithInput();
    }

    private void AttackWithInput()
    {
        if (_playerInputReader.IsAttackKeyInputed)
        {
            Attack<BearHealthHandler>();
        }
    }
}