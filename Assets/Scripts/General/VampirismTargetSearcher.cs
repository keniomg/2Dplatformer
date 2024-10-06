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

    public override TargetHealth GetTarget<TargetHealth>()
    {
        TargetHealth currentFoundedTarget = base.GetTarget<TargetHealth>();
        
        float minimumDistance = TargetSearchRadius;
        float distance;

        if (currentFoundedTarget != null && !_targets.Contains(currentFoundedTarget))
        {
            _targets.Add(currentFoundedTarget);
        }

        for (int i = 0; i < _targets.Count; i++)
        {
            distance = Vector2.Distance(_targets[i].transform.position, transform.position);

            if (distance < minimumDistance)
            {
                NearestTarget = _targets[i];
                minimumDistance = distance;
            }
            else if(distance > TargetSearchRadius)
            {
                _targets.RemoveAt(i);
            }
        }

        if (_targets.Count == 0)
        {
            NearestTarget = null;
        }

        return (TargetHealth)NearestTarget;
    }
}