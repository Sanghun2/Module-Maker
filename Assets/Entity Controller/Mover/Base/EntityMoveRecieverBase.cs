using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

// player, worker 소스만 다르게 공통사용
public abstract class EntityMoveRecieverBase : MonoBehaviour
{
#pragma warning disable CS0414
    [SerializeField] protected float moveSpeed = 5f;
    protected Vector2 moveVec;
#pragma warning restore CS0414

    protected virtual bool CanMove() => true;
    protected abstract void ApplyMove();
    protected abstract void RecieveMoveDirection(Vector2 moveVec);
    protected abstract void ConnectMove();
    protected abstract void UnconnectMove();
    public abstract bool TryConnectMoveSource();
    protected abstract bool IsMoveSourceConnected();

    private void Update() {
        if (CanMove()) {
            ApplyMove();
        }
    }
    private void OnEnable() {
        if (TryConnectMoveSource()) {
            ConnectMove();
        }
    }
    private void OnDisable() {
        if (IsMoveSourceConnected()) {
            UnconnectMove();
        }
    }

    //protected void ApplyGravity() {
    //    _isGrounded = _controller.isGrounded;
    //    if (_isGrounded && _velocity.y < 0f)
    //        _velocity.y = -2f;
    //}
    //protected void MoveByWorldDir(Vector3 worldDir) {
    //    if (worldDir.sqrMagnitude < 0.01f) return;

    //    _controller.Move(worldDir * moveSpeed * Time.deltaTime);

    //    transform.rotation = Quaternion.Slerp(
    //        transform.rotation,
    //        Quaternion.LookRotation(worldDir),
    //        Time.deltaTime * 10f
    //    );
    //}
}
