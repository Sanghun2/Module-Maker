using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MoveInputBase : InputBase, IMovementInput
{
    public Vector2 MoveDirection { get; private set; }

    protected abstract Vector2 SetMoveDirection();

    void Update() {
        MoveDirection = SetMoveDirection();
    }
}