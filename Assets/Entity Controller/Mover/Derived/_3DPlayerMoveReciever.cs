using BilliotGames;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class _3DPlayerMoveReciever : EntityMoveRecieverBase
{
    [SerializeField] Transform cameraTransform;
    [SerializeField] JoystickBase joystickBase;

    protected CharacterController _controller;

    private void Awake() {
        _controller = GetComponent<CharacterController>();
    }

    protected override void ApplyMove() {
        var camForward = Vector3.ProjectOnPlane(cameraTransform.forward, Vector3.up).normalized;
        var camRight = Vector3.ProjectOnPlane(cameraTransform.right, Vector3.up).normalized;
        var worldDir = (camForward * moveVec.y + camRight * moveVec.x);
        _controller.Move(worldDir * moveSpeed * Time.deltaTime);
    }


    public override bool TryConnectMoveSource() {
        if (joystickBase == null) {
            joystickBase = GameObject.FindAnyObjectByType<JoystickBase>();
        }

        return joystickBase != null;
    }
    protected override void ConnectMove() {
        joystickBase.OnDirectionChanged -= RecieveMoveDirection;
        joystickBase.OnDirectionChanged += RecieveMoveDirection;
    }
    protected override void UnconnectMove() {
        joystickBase.OnDirectionChanged -= RecieveMoveDirection;
    }

    protected override bool IsMoveSourceConnected() {
        return joystickBase != null;
    }

    protected override bool CanMove() {
        return true;
    }
    protected override void RecieveMoveDirection(Vector2 moveVec) {
        this.moveVec = moveVec;
    }
}