using UnityEngine;
using UnityEngine.Events;

namespace BilliotGames
{
    public abstract class ObjectDetector : MonoBehaviour
    {
        public abstract RaycastHit? FirstDetectedObject { get; }

        [Header("[  Common Detect Options  ]")]
        [SerializeField] protected bool canDetect = true;
        [SerializeField] protected Transform startPointTr;
        [SerializeField] protected Vector3 raycastOffset;
        [SerializeField] protected LayerMask ignoreLayers;

        public event UnityAction<RaycastHit[]> OnNewObjectDetected;

        protected bool _isInit;
        protected RaycastHit[] detectedObjects;

        public abstract void ShootRaycast();

        protected virtual void Init() {
            if (_isInit) return;
            _isInit = true;
        }
        protected void InvokeNewObjectDetected(RaycastHit[] raycastHit) {
            OnNewObjectDetected?.Invoke(raycastHit);
        }

        private void Awake() {
            Init();
        }
        private void Reset() {
            if (startPointTr == null) {
                startPointTr = transform;
            }
        }

        protected abstract bool IsEqualObject(Collider prevCollider, Collider newCollider);
        protected abstract bool IsValidHit(RaycastHit hitInfo);

#if UNITY_EDITOR
        private void OnDrawGizmos() {
            DrawRaycastGizmos();
        }
#endif

        protected virtual void DrawRaycastGizmos() { }
    }
}
