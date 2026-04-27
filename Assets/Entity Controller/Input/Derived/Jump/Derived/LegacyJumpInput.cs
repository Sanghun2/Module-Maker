using UnityEngine;

public class LegacyJumpInput : JumpInputBase
{
    public override bool ReadJump() => Input.GetButtonDown("Jump");
}
