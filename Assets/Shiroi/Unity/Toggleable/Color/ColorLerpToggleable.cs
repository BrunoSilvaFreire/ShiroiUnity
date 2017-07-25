using UnityEngine;

namespace Shiroi.Unity.Toggleable.Color {
    public abstract class ColorLerpToggleable<S> : LerpToggleable<S, UnityEngine.Color> {
        [SerializeField]
        private UnityEngine.Color onThreshold = UnityEngine.Color.white;

        [SerializeField]
        private UnityEngine.Color offThreshold = UnityEngine.Color.black;


        public override UnityEngine.Color OnThreshold {
            get { return onThreshold; }
        }

        public override UnityEngine.Color OffThreshold {
            get { return offThreshold; }
        }

        protected override UnityEngine.Color Lerp(UnityEngine.Color a, UnityEngine.Color b, float alpha) {
            return UnityEngine.Color.Lerp(a, b, alpha);
        }
    }
}