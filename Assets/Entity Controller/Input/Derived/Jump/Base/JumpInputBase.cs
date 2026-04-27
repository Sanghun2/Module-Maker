using UnityEngine;

public abstract class JumpInputBase : InputBase, IJumpInput
{
    public abstract bool ReadJump();
}
