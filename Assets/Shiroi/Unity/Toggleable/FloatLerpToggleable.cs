using System;
using UnityEngine;

namespace Shiroi.Unity.Toggleable {
    public abstract class FloatLerpToggleable<S> : LerpToggleable<S, float> {
        [SerializeField]
        private float onThreshold = 0.95F;

        [SerializeField]
        private float offThreshold = 0.05F;


        public override float OnThreshold {
            get { return onThreshold; }
        }

        public override float OffThreshold {
            get { return offThreshold; }
        }

        protected override bool IsUnderThreshold(float value, float threshold) {
            return value < threshold;
        }

        protected override bool IsOverThreshold(float value, float threshold) {
            return value > threshold;
        }

        protected override float Lerp(float a, float b, float alpha) {
            return Mathf.Lerp(a, b, alpha);
        }
    }
}