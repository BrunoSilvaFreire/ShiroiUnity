namespace Shiroi.Unity.Toggleable.Color {
    public abstract class AlphaColorLerpToggleable<S> : ColorLerpToggleable<S> {
        protected override bool IsUnderThreshold(UnityEngine.Color value, UnityEngine.Color threshold) {
            return value.a < threshold.a;
        }

        protected override bool IsOverThreshold(UnityEngine.Color value, UnityEngine.Color threshold) {
            return value.a > threshold.a;
        }
    }
}