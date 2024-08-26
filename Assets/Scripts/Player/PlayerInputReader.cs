using UnityEngine;

public class PlayerInputReader : MonoBehaviour
{
    public const string Horizontal = "Horizontal";
    public const KeyCode JumpKey = KeyCode.Space;
    public const KeyCode AttackKey = KeyCode.Mouse0;

    public float HorizontalAxisValue => Input.GetAxis(Horizontal);
    public bool IsJumpKeyInputed => Input.GetKeyDown(JumpKey);
    public bool IsAttackKeyInputed => Input.GetKeyDown(AttackKey);
}