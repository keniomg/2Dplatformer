using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthTextUI : HealthTextUI
{
    [SerializeField] private Eventer _eventer;

    private void OnEnable()
    {
        _eventer.PlayerHealthCreated += Initialize;
    }

    private void OnDisable()
    {
        _eventer.PlayerHealthCreated -= Initialize;

        if (Health != null)
        {
            Health.ValueChanged -= OnHealthChanged;
        }
    }
}