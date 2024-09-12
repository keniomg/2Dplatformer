using UnityEngine;

public class PlayerInputReader : MonoBehaviour
{
    public const string Horizontal = "Horizontal";
    public const KeyCode JumpKey = KeyCode.Space;
    public const KeyCode AttackKey = KeyCode.Mouse0;

    private PlayerStatus _status;

    public float HorizontalAxisValue { get; private set; }
    public bool IsJumpInputed {get; private set; }
    public bool IsAttackKeyInputed { get; private set; }

    public void Initialize(PlayerStatus status)
    {
        _status = status;
    }

    public void HandleInput()
    {
        HorizontalAxisValue = Input.GetAxis(Horizontal);
        IsAttackKeyInputed = Input.GetKeyDown(AttackKey);

        if (Input.GetKeyDown(JumpKey) && _status.IsGrounded)
        {
            IsJumpInputed = true;
        }
    }

    public void ResetJumpInput()
    {
        IsJumpInputed = false;
    }
}