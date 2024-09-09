using UnityEngine;

public class PlayerInputReader : MonoBehaviour
{
    public const string Horizontal = "Horizontal";
    public const KeyCode JumpKey = KeyCode.Space;
    public const KeyCode AttackKey = KeyCode.Mouse0;

    public float HorizontalAxisValue { get; private set; }
    public bool IsJumpKeyInputed {get; private set; }
    public bool IsAttackKeyInputed { get; private set; }

    public void HandleInput()
    {
        HorizontalAxisValue = Input.GetAxis(Horizontal);
        IsJumpKeyInputed = Input.GetKeyDown(JumpKey);
        IsAttackKeyInputed = Input.GetKeyDown(AttackKey);
    }
}