using System;
using Shiroi.Unity.Layout;

namespace Shiroi.Unity.Toggleable.Layout {
    public class RadialLayoutToggleable : FloatLerpToggleable<RadialLayout> {
        [Flags]
        public enum RadialLayoutToggleableTarget {
            Radius = 0,
            MinAngle = 1,
            MaxAngle = 2,
            StartAngle = 3
        }

        public RadialLayoutToggleableTarget LayoutTarget = RadialLayoutToggleableTarget.Radius;

        protected override void SetValue(float value, RadialLayout source) {
            switch (LayoutTarget) {
                case RadialLayoutToggleableTarget.Radius:
                    source.Radius = value;
                    break;
                case RadialLayoutToggleableTarget.MinAngle:
                    source.MinAngle = value;
                    break;
                case RadialLayoutToggleableTarget.MaxAngle:
                    source.MaxAngle = value;
                    break;
                case RadialLayoutToggleableTarget.StartAngle:
                    source.StartAngle = value;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        protected override float GetValue(RadialLayout source) {
            switch (LayoutTarget) {
                case RadialLayoutToggleableTarget.Radius:
                    return source.Radius;
                case RadialLayoutToggleableTarget.MinAngle:
                    return source.MinAngle;
                case RadialLayoutToggleableTarget.MaxAngle:
                    return source.MaxAngle;
                case RadialLayoutToggleableTarget.StartAngle:
                    return source.StartAngle;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}