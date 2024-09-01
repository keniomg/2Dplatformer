using UnityEngine;

[RequireComponent(typeof(BearAnimator), typeof(BearAnimatorData), typeof(BearAttacker))]
[RequireComponent(typeof(BearGroundDetector), typeof(BearHealth), typeof(BearMover))]
[RequireComponent(typeof(BearStatus), typeof(BearTargetSearcher))]

public class Bear : MonoBehaviour { }