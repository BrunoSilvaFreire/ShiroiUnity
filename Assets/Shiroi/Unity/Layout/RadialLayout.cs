using UnityEngine;
using UnityEngine.UI;

namespace Shiroi.Unity.Layout {
    public class RadialLayout : LayoutGroup {
        [SerializeField]
        private float radius = 5;

        [Range(0f, 360f), SerializeField]
        private float minAngle;

        [Range(0f, 360f), SerializeField]
        private float maxAngle = 360;

        [Range(0f, 360f), SerializeField]
        private float startAngle = 90;

        public float Radius {
            get { return radius; }
            set {
                radius = value;
                UpdatePositions();
            }
        }

        public float MinAngle {
            get { return minAngle; }
            set {
                minAngle = value;
                UpdatePositions();
            }
        }

        public float MaxAngle {
            get { return maxAngle; }
            set {
                maxAngle = value;
                UpdatePositions();
            }
        }

        public float StartAngle {
            get { return startAngle; }
            set {
                startAngle = value;
                UpdatePositions();
            }
        }

        protected override void OnEnable() {
            base.OnEnable();
            UpdatePositions();
        }

        public override void SetLayoutHorizontal() { }
        public override void SetLayoutVertical() { }

        public override void CalculateLayoutInputVertical() {
            UpdatePositions();
        }

        public override void CalculateLayoutInputHorizontal() {
            UpdatePositions();
        }

#if UNITY_EDITOR
        protected override void OnValidate() {
            base.OnValidate();
            UpdatePositions();
        }
#endif
        private void UpdatePositions() {
            m_Tracker.Clear();
            if (transform.childCount == 0) {
                return;
            }

            var angleIncrementation = (MaxAngle - MinAngle) / transform.childCount;
            for (var i = 0; i < transform.childCount; i++) {
                var angle = StartAngle + i * angleIncrementation;
                var child = (RectTransform) transform.GetChild(i);
                if (child == null) {
                    continue;
                }
                m_Tracker.Add(
                    this,
                    child,
                    DrivenTransformProperties.Anchors |
                    DrivenTransformProperties.AnchoredPosition |
                    DrivenTransformProperties.Pivot);

                var pos = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad));
                child.localPosition = pos * Radius;
                child.anchorMin = child.anchorMax = child.pivot = new Vector2(0.5f, 0.5f);
            }
        }
    }
}