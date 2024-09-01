public class PlayerTargetSearcher : TargetSearcher
{
    private PlayerInputReader _playerInputReader;

    protected void Start()
    {
        _playerInputReader = TryGetComponent(out PlayerInputReader playerInputReader) ? playerInputReader : null;
    }

    private void Update()
    {
        SearchBear();
    }

    private void SearchBear()
    {
        if (_playerInputReader.IsAttackKeyInputed)
        {
            Target = GetTarget<BearHealth>();
        }
    }
}