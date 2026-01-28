using UnityEngine;

namespace BilliotGames
{
    public abstract class FrameBasedObjectDetector : ObjectDetector
    {
        [Space]
        [Header("[  Frame Detect Options  ]")]
        [SerializeField] protected int detectFrameInterval = 10;

        private void FixedUpdate() {
            if (!canDetect) return;
            if (Time.frameCount % detectFrameInterval == 0) ShootRaycast();
        }
    }
}

