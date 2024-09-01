using UnityEngine;

public class PlayerGroundDetector : GroundDetector
{
    public bool IsGrounded { get; private set; }

    private void Update()
    {
        float checkRadius = 0.1f;
        IsGrounded = Physics2D.OverlapCircle(GroundCheckPoint.position, checkRadius, Ground);
    }
}