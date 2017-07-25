namespace Shiroi.Unity.Toggleable.Light {
    public class LightIntensityToggleable : FloatLerpToggleable<UnityEngine.Light> {
        protected override void SetValue(float value, UnityEngine.Light source) {
            source.intensity = value;
        }

        protected override float GetValue(UnityEngine.Light source) {
            return source.intensity;
        }
    }
}