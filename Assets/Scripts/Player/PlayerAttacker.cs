using UnityEngine;

public class PlayerAttacker : Attacker
{
    private PlayerInputReader _playerInputReader;
    private PlayerMover _playerMover;

    public override Vector2 AttackDirection => _playerMover.MoveDirection;

    public void Initialize(PlayerInputReader playerInputReader, PlayerAnimatorData playerAnimatorData, PlayerTargetSearcher playerTargetSearcher, PlayerMover playerMover)
    {
        _playerInputReader = playerInputReader;
        AnimatorData = playerAnimatorData;
        Searcher = playerTargetSearcher;
        _playerMover = playerMover;
    }

    public void AttackWithInput()
    {
        if (_playerInputReader.IsAttackKeyInputed)
        {
            Searcher.InitializeTarget();
            Attack<BearHealth>();
        }
    }
}