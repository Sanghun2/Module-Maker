using UnityEngine;

namespace BilliotGames
{
    public class LineObjectDetector : FrameBasedObjectDetector
    {
        public override RaycastHit? FirstDetectedObject
        {
            get
            {
                if (detectedObjects == null || detectedObjects.Length == 0)
                    return null;

                var hit = detectedObjects[0];
                return hit.collider != null ? hit : null;
            }
        }

        [Space]
        [Header("[  Line Detect Options  ]")]
        [SerializeField] float rayDistance = 3f;

        public override void ShootRaycast() {
            if (Physics.Raycast(transform.position + raycastOffset, startPointTr.forward, out RaycastHit hitInfo, rayDistance, ~ignoreLayers)) {
                if (IsValidHit(hitInfo)) {
                    RaycastHit? prevDetectedObject = FirstDetectedObject;
                    if (!IsEqualObject(prevDetectedObject?.collider, hitInfo.collider)) {
                        detectedObjects[0] = hitInfo;
                        InvokeNewObjectDetected(detectedObjects);
                    }
                }
            }
            else {
                if (FirstDetectedObject?.collider != null) {
                    detectedObjects[0] = default;
                    InvokeNewObjectDetected(detectedObjects);
                }
            }
        }


        protected override void Init() {
            if (_isInit) return;
            detectedObjects = new RaycastHit[1];
            _isInit = true;
        }

        protected override void DrawRaycastGizmos() {
            if (startPointTr == null) return;
            Debug.DrawRay(startPointTr.position + raycastOffset, startPointTr.forward * rayDistance, Color.green);
        }

        protected override bool IsEqualObject(Collider prevCollider, Collider newCollider) {
            if (prevCollider == null || newCollider == null) return false;

            return prevCollider.Equals(newCollider);
        }

        protected override bool IsValidHit(RaycastHit hitInfo) {
            return hitInfo.collider != null;
        }
    }
}
