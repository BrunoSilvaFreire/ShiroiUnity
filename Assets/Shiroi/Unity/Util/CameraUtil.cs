using UnityEngine;

namespace Shiroi.Unity.Util {
    public static class CameraUtil {
        public static float GetOrthographicSizeX(this Camera camera) {
            return camera.orthographicSize * camera.aspect;
        }
    }
}