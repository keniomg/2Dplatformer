using UnityEngine;

public class PlayerGroundDetector : GroundDetector
{
    public bool GetGroundedStatus()
    {
        float checkRadius = 0.1f;
        bool isGrounded = Physics2D.OverlapCircle(GroundCheckPoint.position, checkRadius, Ground);
        return isGrounded;
    }
}