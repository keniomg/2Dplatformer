using UnityEngine;

public class BearTargetSearcher : TargetSearcher
{
    public float DistanceToTarget {get; private set; }

    private void Update()
    {
        DistanceToTarget = GetDistanceToTarget();
    }

    private float GetDistanceToTarget()
    {
        Target = GetTarget<PlayerHealthHandler>();
        float distance = 0;

        if (Target != null)
        {
            distance = Vector2.Distance(Target.transform.position, transform.position);
        }

        return distance;
    }
}