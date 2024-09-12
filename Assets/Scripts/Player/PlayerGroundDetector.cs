using UnityEngine;

public class PlayerGroundDetector : GroundDetector
{
    public bool GetGroundedStatus()
    {
        float checkRadius = 0.1f;
        return Physics2D.OverlapCircle(GroundCheckPoint.position, checkRadius, Ground);
    }
}