using UnityEngine;

[RequireComponent(typeof(PlayerInputReader))]

public class PlayerTargetSearcher : TargetSearcher
{
    private PlayerInputReader _playerInputReader;

    protected override void Start()
    {
        base.Start();
        _playerInputReader = GetComponent<PlayerInputReader>();
    }

    protected void Update()
    {
        SearchBear();
    }

    private void SearchBear()
    {
        if (_playerInputReader.IsAttackKeyInputed)
        {
            Target = GetTarget<BearHealthHandler>();
        }
    }
}