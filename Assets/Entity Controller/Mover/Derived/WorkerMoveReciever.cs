// WorkerMoveReciever.cs — 카메라 무관, 월드 방향 직접 결정
using UnityEngine;

public class WorkerMoveReciever : EntityMoveRecieverBase
{
    public override bool TryConnectMoveSource() {
        throw new System.NotImplementedException();
    }

    protected override void ApplyMove() {
        throw new System.NotImplementedException();
    }

    protected override void ConnectMove() {
        throw new System.NotImplementedException();
    }

    protected override bool IsMoveSourceConnected() {
        throw new System.NotImplementedException();
    }

    protected override void RecieveMoveDirection(Vector2 moveVec) {
        throw new System.NotImplementedException();
    }

    protected override void UnconnectMove() {
        throw new System.NotImplementedException();
    }
}