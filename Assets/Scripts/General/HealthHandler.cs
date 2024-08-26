using UnityEngine;

public class HealthHandler : MonoBehaviour
{
    protected int _currentHealthValue;
    protected int _maximumHealthValue;
    protected int _minimumHealthValue;
    protected AttackHandler _attackHandler;

    protected virtual void Start()
    {
        int startHealthValue = 100;
        _currentHealthValue = startHealthValue;
        _minimumHealthValue = 0;
        _maximumHealthValue = 100;
    }

    protected virtual void OnDisable()
    {
        if (_attackHandler != null)
        {
            _attackHandler.DamageDealed -= OnTakedDamage;
        }
    }

    public void InitializeAttackHandler(AttackHandler attackHandler)
    {
        if (_attackHandler != null)
        {
            _attackHandler.DamageDealed -= OnTakedDamage;
        }

        _attackHandler = attackHandler;
        _attackHandler.DamageDealed += OnTakedDamage;
    }

    protected virtual void OnTakedDamage(AttackHandler attackHandler)
    {
        _currentHealthValue -= attackHandler.AttackDamage;

        if (_currentHealthValue < _minimumHealthValue)
        {
            _currentHealthValue = _minimumHealthValue;
        }
    }

    protected virtual void IncreaseHealth(int healingValue)
    {
        _currentHealthValue += healingValue;

        if (_currentHealthValue > _maximumHealthValue)
        {
            _currentHealthValue = _maximumHealthValue;
        }
    }
}