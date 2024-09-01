using UnityEngine;

[RequireComponent(typeof(PlayerGroundDetector), typeof(PlayerAnimatorData), typeof(PlayerAnimator))]
[RequireComponent(typeof(PlayerAttacker), typeof(PlayerCollider), typeof(PlayerHealth))]
[RequireComponent(typeof(PlayerInputReader), typeof(PlayerMover), typeof(PlayerStatus))]
[RequireComponent(typeof(PlayerTargetSearcher))]

public class Player : MonoBehaviour { }