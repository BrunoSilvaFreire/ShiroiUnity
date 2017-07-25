using UnityEngine;

namespace Shiroi.Unity.Toggleable.Color {
    public abstract class VectorColorLerpToggleable<S> : ColorLerpToggleable<S> {
        protected override bool IsUnderThreshold(UnityEngine.Color value, UnityEngine.Color threshold) {
            return ((Vector4) value).magnitude < ((Vector4) threshold).magnitude;
        }

        protected override bool IsOverThreshold(UnityEngine.Color value, UnityEngine.Color threshold) {
            return ((Vector4) value).magnitude > ((Vector4) threshold).magnitude;
        }
    }
}