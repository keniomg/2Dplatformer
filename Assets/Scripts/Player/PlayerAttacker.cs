public class PlayerAttacker : Attacker
{
    private PlayerInputReader _playerInputReader;

    public void Inititalize(PlayerInputReader playerInputReader, PlayerAnimatorData playerAnimatorData, PlayerTargetSearcher playerTargetSearcher)
    {
        _playerInputReader = playerInputReader;
        AnimatorData = playerAnimatorData;
        Searcher = playerTargetSearcher;
    }

    public void AttackWithInput()
    {
        if (_playerInputReader.IsAttackKeyInputed)
        {
            Attack<BearHealth>();
        }
    }
}