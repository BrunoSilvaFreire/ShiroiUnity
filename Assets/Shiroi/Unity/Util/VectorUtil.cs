using UnityEngine;

namespace Shiroi.Unity.Util {
    public static class VectorUtil {
        public static Vector2 Multiply(this Vector2 a, Vector2 b) {
            return new Vector2(a.x * b.x, a.y * b.y);
        }
    }
}