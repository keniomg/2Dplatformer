public class PlayerAttacker : Attacker
{
    private PlayerInputReader _playerInputReader;

    protected override void Start()
    {
        _playerInputReader = TryGetComponent(out PlayerInputReader playerInputReader) ? playerInputReader : null;
        AnimatorData = TryGetComponent(out PlayerAnimatorData playerAnimatorData) ? playerAnimatorData : null;
        Searcher = TryGetComponent(out PlayerTargetSearcher playerTargetSearcher) ? playerTargetSearcher : null;
        Mover = TryGetComponent(out PlayerMover mover) ? mover : null;

        base.Start();
    }

    private void FixedUpdate()
    {
        AttackWithInput();
    }

    private void AttackWithInput()
    {
        if (_playerInputReader.IsAttackKeyInputed)
        {
            Attack<BearHealth>();
        }
    }
}