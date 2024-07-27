using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class ForbiddenZone : MonoBehaviour 
{
    [SerializeField] private Alarm _alarm;

    public event Action RogueEnteredZone;
    public event Action RogueLeftZone;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out RogueMover rogue))
        {
            RogueEnteredZone?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out RogueMover rogue))
        {
            RogueLeftZone?.Invoke();
        }
    }
}