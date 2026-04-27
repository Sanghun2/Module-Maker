using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LegacyMoveInput : MoveInputBase
{
    protected override Vector2 SetMoveDirection() =>
        new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
}