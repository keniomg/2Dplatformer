using UnityEngine;

[RequireComponent(typeof(PlayerCollisionHandler))]

public class PlayerHealthHandler : HealthHandler
{
    private Cherry _cherry;
    private PlayerCollisionHandler _playerCollisionHandler;

    private void Awake()
    {
        _playerCollisionHandler = GetComponent<PlayerCollisionHandler>();
    }

    protected override void Start()
    {
        _maximumHealthValue = 150;
        int startHealthValue = _maximumHealthValue;
        _currentHealthValue = startHealthValue;
    }

    private void OnEnable()
    {
        _playerCollisionHandler.PlayerCollisionCherry += OnPlayerCollisionCherry;
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        _playerCollisionHandler.PlayerCollisionCherry -= OnPlayerCollisionCherry;
    }

    public void InitializeCherry(Cherry cherry)
    {
        _cherry = cherry;
    }

    protected override void OnTakedDamage(AttackHandler attackHandler)
    {
        base.OnTakedDamage(attackHandler);
        PrintHealthMessage();
    }

    private void OnPlayerCollisionCherry()
    {
        IncreaseHealth(_cherry.HealingValue);
        PrintHealthMessage();
    }

    private void PrintHealthMessage()
    {
        string healthMessage = $"Текущее здоровье игрока - {_currentHealthValue}";
        Debug.Log(healthMessage);
    }
}