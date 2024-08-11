using UnityEngine;

public class PlayerInputReader : MonoBehaviour
{
    public const string Horizontal = "Horizontal";
    public const KeyCode JumpKey = KeyCode.Space;

    public float HorizontalAxisValue => Input.GetAxis(Horizontal);
    public bool IsJumpKeyInputed => Input.GetKeyDown(JumpKey);
}