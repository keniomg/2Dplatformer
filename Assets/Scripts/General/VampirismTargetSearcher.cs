using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class VampirismTargetSearcher : TargetSearcher
{
    public Health NearestTarget { get; private set; }

    public override TargetHealth GetTarget<TargetHealth>()
    {
        List<TargetHealth> targets = GetTargets<TargetHealth>();

        if (targets == null || targets.Count == 0)
        {
            return null;
        }

        TargetHealth nearestTarget = targets.OrderBy(target => Vector2.Distance(transform.position, target.transform.position)).FirstOrDefault();
        NearestTarget = nearestTarget;

        return nearestTarget;
    }

    private List<TargetHealth> GetTargets<TargetHealth>() where TargetHealth : Health
    {
        Collider2D[] targetHits = Physics2D.OverlapCircleAll(transform.position, TargetSearchRadius, TargetLayer);
        List<TargetHealth> targets = new List<TargetHealth>();

        if (targetHits != null)
        {
            for (int i = 0; i < targetHits.Length; i++)
            {
                if (targetHits[i].TryGetComponent(out TargetHealth targetHealth) || targetHits[i].transform.parent.TryGetComponent(out targetHealth))
                {
                    targets.Add(targetHealth);
                }
            }
        }

        return targets;
    }
}