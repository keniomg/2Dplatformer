using UnityEngine;

[RequireComponent(typeof(Collider))]

public class ForbiddenZone : MonoBehaviour 
{
    [SerializeField] private Alarm _alarm;

    private bool _isRogueInZone;

    private void Update()
    {
        _alarm.UpdateBurglaryStatus(_isRogueInZone);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out RogueMover rogue))
        {
            _isRogueInZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out RogueMover rogue))
        {
            _isRogueInZone = false;
        }
    }
}