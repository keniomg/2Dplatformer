using System.Collections;
using UnityEngine;

public class Vampire : MonoBehaviour
{
    protected VampirismTargetSearcher TargetSearcher;

    private int _vampirismPerSecond = 5;
    private int _abilityDuration = 6;
    private int _abilityCooldown = 3;
    private bool _isAbilityAvailable;
    private Health _selfHealth;
    private Coroutine _ability;
    private Coroutine _cooldown;
    private WaitForSeconds _vampirismDelay;
    private WaitForSeconds _cooldownDelay;

    public int AbilityDurationLeft { get; private set; }
    public int CurrentAbilityCooldown { get; private set; }
    public bool IsAbilityActive {get; private set; }
    public float VampirismRadius => TargetSearcher.TargetSearchRadius;
    public int MaximumAbilityDuration => _abilityDuration;
    public int MaximumAbilityCooldown => _abilityCooldown;

    private void Start()
    {
        _isAbilityAvailable = true;
        const int SecondDelay = 1;
        _vampirismDelay = new WaitForSeconds(SecondDelay);
        _cooldownDelay = new WaitForSeconds(SecondDelay);
    }

    public void Initialize(Health health, VampirismTargetSearcher targetSearcher)
    {
        _selfHealth = health;
        TargetSearcher = targetSearcher;
    }

    public virtual void OnButtonPressed()
    {
        if (_isAbilityAvailable && _ability == null)
        {
            _ability = StartCoroutine(Vampirism());
        }
    }

    private IEnumerator Vampirism()
    {
        IsAbilityActive = true;
        _isAbilityAvailable = false;
        AbilityDurationLeft = _abilityDuration;

        while (AbilityDurationLeft > 0)
        {
            if (TargetSearcher.NearestTarget != null)
            {
                TargetSearcher.NearestTarget.Decrease(_vampirismPerSecond);
                _selfHealth.Increase(_vampirismPerSecond);
            }

            yield return _vampirismDelay;
            AbilityDurationLeft--;
        }
        
        _ability = null;
        _cooldown = StartCoroutine(Cooldown());

        if (_cooldown == null)
        {
            _isAbilityAvailable = true;
        }
    }

    private IEnumerator Cooldown()
    {
        CurrentAbilityCooldown = 0;

        while (CurrentAbilityCooldown < _abilityCooldown)
        {
            yield return _cooldownDelay;
            CurrentAbilityCooldown++;
        }

        _cooldown = null;
    }
}