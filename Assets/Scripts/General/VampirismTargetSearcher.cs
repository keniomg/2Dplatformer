using System.Collections.Generic;
using UnityEngine;

public class VampirismTargetSearcher : TargetSearcher
{
    private List<Health> _targets;

    public Health NearestTarget {get; private set; }

    private void Start()
    {
        _targets = new List<Health>();
    }

    public void ChooseNearestTarget<TargetHealth>() where TargetHealth : Health
    {
        TargetHealth currentFoundedTarget = GetTarget<TargetHealth>();
        float minimumDistance = TargetSearchRadius;

        if (currentFoundedTarget != null && !_targets.Contains(currentFoundedTarget))
        {
            _targets.Add(currentFoundedTarget);
        }

        for (int i = 0; i < _targets.Count; i++)
        {
            float distance = Vector2.Distance(_targets[i].transform.position, transform.position);

            if (distance < minimumDistance)
            {
                minimumDistance = distance;
                NearestTarget = _targets[i];
            }
        }
    }
}