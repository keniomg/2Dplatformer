using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    public void PlayerCollisionDiamond(Diamond diamond)
    {
        diamond.SetPickedUpStatus();
    }
}