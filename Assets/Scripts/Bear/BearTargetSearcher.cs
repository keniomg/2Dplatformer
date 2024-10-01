using UnityEngine;

public class BearTargetSearcher : TargetSearcher
{
    public float DistanceToTarget {get; private set; }

    public override void InitializeTarget<TargetHealth>()
    {
        Target = GetTarget<TargetHealth>();
        DistanceToTarget = GetDistanceToTarget();
    }

    private float GetDistanceToTarget()
    {
        float distance = 0;

        if (Target != null)
        {
            distance = Vector2.Distance(Target.transform.position, transform.position);
        }

        return distance;
    }
}