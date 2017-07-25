using Shiroi.Unity.Toggleable.Color;

namespace Shiroi.Unity.Toggleable.Light {
    public class LightAlphaColorToggleable : AlphaColorLerpToggleable<UnityEngine.Light> {
        protected override void SetValue(UnityEngine.Color value, UnityEngine.Light source) {
            source.color = value;
        }

        protected override UnityEngine.Color GetValue(UnityEngine.Light source) {
            return source.color;
        }
    }
}